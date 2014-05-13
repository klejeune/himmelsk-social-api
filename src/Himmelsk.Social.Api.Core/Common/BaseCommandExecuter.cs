using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;
using Himmelsk.Social.Api.Core.LinkedIn.Results;
using Himmelsk.Social.Api.Core.LinkedIn;

namespace Himmelsk.Social.Api.Core.Common {
    class BaseCommandExecuter<TCredentials> : ICommandExecuter<TCredentials> where TCredentials : ICredentials {
        public IResult<TResult> Execute<TResult>(TCredentials credentials, ICommand<TResult> command) {
            string result;

            var uri = this.GetFullUri(command);
            uri = this.AlterUri(credentials, command, uri);
            var hwr = (HttpWebRequest)WebRequest.Create(uri);
            hwr.Method = this.GetVerb(command.Verb);

            if (!string.IsNullOrEmpty(command.ContentType)) {
                hwr.ContentType = command.ContentType;
            }

            this.AddHeader(credentials, command, hwr);
            
            command.AddHeaders((key, value) => hwr.Headers.Add(key, value));

            //GS - POST off the request
            
            //hwr.ContentType = "application/x-www-form-urlencoded";

            if (command.Verb == CommandVerb.Post) {
                Stream requestStream = hwr.GetRequestStream();
                byte[] bodyBytes = new ASCIIEncoding().GetBytes(this.GetPost(command));

                requestStream.Write(bodyBytes, 0, bodyBytes.Length);
                requestStream.Flush();
                requestStream.Close();
            }
            else {
                if (!string.IsNullOrEmpty(this.GetPost(command))) {
                    throw new InvalidOperationException("Cannot send command with GET verb and POST parameters");
                }
            }

            //GS - Allow us a reasonable timeout in case
            //Twitter's busy
            hwr.Timeout = 3 * 60 * 1000;

            WebResponse webResponse;

            try {
                webResponse = hwr.GetResponse();
                //GS - Do something with the return here...
            } catch (WebException e) {
                webResponse = e.Response;
            }

            var response = webResponse as HttpWebResponse;

            using (var responseStream = new StreamReader(response.GetResponseStream())) {
                result = responseStream.ReadToEnd();
            }

            Error error = null;
            TResult formattedResult = default(TResult);
            var statusCode = (int) response.StatusCode;

            if (statusCode == 500 || statusCode == 403 || statusCode == 401) {
                throw new ApiErrorException(new Result<Error> {
                    Raw = result,
                    Typed = command.FormatError(result, response.ContentType),
                });
            }
            else {
                formattedResult = command.FormatResult(result, response.ContentType);
            }

            return new Result<TResult> {
                Raw = result,
                Typed = formattedResult,
            };
        }

        protected virtual string AlterUri<TResult>(TCredentials credentials, ICommand<TResult> command, string uri) {
            return uri;
        }

        protected virtual void AddHeader<TResult>(TCredentials credentials, ICommand<TResult> command, HttpWebRequest request) {
            
        }

        protected IDictionary<string, string> GetAllParameters(ICommand command) {
            return command.GetParameters
                .Union(command.PostParameters)
                .OrderBy(pair => pair.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private string GetVerb(CommandVerb verb) {
            switch (verb) {
                case CommandVerb.Get:
                    return "GET";
                case CommandVerb.Post:
                    return "POST";
                default:
                    throw new NotImplementedException("Verb " + verb + " is not implemented.");
            }
        }

        private string GetFullUri(ICommand command) {
            var parameters = command.GetParameters.ToList();
            var url = command.BaseUrl;

            if (parameters.Any()) {
                url += "?" + string.Join("&", parameters.Select(pair => pair.Key + '=' + pair.Value));
            }

            return url;
        }

        private string GetPost(ICommand command) {
            if (command.PostParameters.Any() && !string.IsNullOrEmpty(command.PostContent)) {
                throw new InvalidOperationException("You cannot use post parameters and define a post content. Use only one of these options.");
            }

            if (command.PostParameters.Any()) {
                return string.Join("&", command.PostParameters.Select(pair => pair.Key + '=' + pair.Value));
            }

            if (!string.IsNullOrEmpty(command.PostContent)) {
                return command.PostContent;
            }

            return string.Empty;
        }
    }
}
