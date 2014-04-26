using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;

namespace Himmelsk.Social.Api.Core.Twitter {
    class TwitterCommandExecuter : BaseCommandExecuter<ITwitterCredentials> {
        protected override void AddHeader<TResult>(ITwitterCredentials credentials, ICommand<TResult> command, HttpWebRequest request) {
            base.AddHeader(credentials, command, request);

            var verb = request.Method;

            var authorization = credentials.GetAuthorization(verb, command.BaseUrl, this.GetAllParameters(command));
            request.Headers.Add("Authorization", authorization);
            request.ContentType = "application/x-www-form-urlencoded";
        }
    }
}
