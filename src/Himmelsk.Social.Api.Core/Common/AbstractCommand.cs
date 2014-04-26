using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;
using Himmelsk.Social.Api.Core.LinkedIn.Converters;
using Himmelsk.Social.Api.Core.LinkedIn.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Himmelsk.Social.Api.Core.Common {
    abstract class AbstractCommand<TResult> : ICommand<TResult> where TResult : class {
        public abstract CommandVerb Verb { get; }
        public abstract void RegisterParameters(IParameterRegisterer registerer);

        public abstract string BaseUrl { get; }

        public IDictionary<string, string> GetAllParameters() {
            var parameters = new ParameterRegisterer();
            this.RegisterParameters(parameters);

            return parameters.GetAllParameters();
        }

        public IEnumerable<IParameter> PostParameters {
            get {
                var parameters = new ParameterRegisterer();
                this.RegisterParameters(parameters);

                return
                    parameters.ParametersPost.Select(
                        pair => new Parameter { Key = pair.Key, Value = pair.Value });
            }
        }

        public string PostContent {
            get {
                var parameters = new ParameterRegisterer();
                this.RegisterParameters(parameters);

                return
                    parameters.PostContent;
            }
        }

        public IEnumerable<IParameter> GetParameters {
            get {
                var parameters = new ParameterRegisterer();
                this.RegisterParameters(parameters);

                return
                    parameters.ParametersGet.Select(
                        pair => new Parameter { Key = pair.Key, Value = pair.Value });
            }
        }

        public virtual string ContentType { get { return "application/json"; } }

        public virtual void AddHeaders(Action<string, string> add) {
        }

        protected virtual T FormatResult<T>(string value, string contentType) where T : class {
            T result;

            if (typeof(T) == typeof (string)) {
                return value as T;
            }
            else if (contentType.StartsWith("application/json") || contentType.StartsWith("text/javascript")) {
                var settings = new JsonSerializerSettings {
                    ContractResolver = new LinkedInJsonConverter(),
                };

                result = JsonConvert.DeserializeObject<T>(value, settings);
            }
            else if (false) {
                var serializer = new XmlSerializer(typeof(T));

                using (var reader = new StringReader(value)) {
                    result = (T)serializer.Deserialize(reader);
                }
            }
            else {
                throw new InvalidOperationException("Response Content Type not supported: " + contentType);
            }

            return result;
        }

        public TResult FormatResult(string value, string contentType) {
            return this.FormatResult<TResult>(value, contentType);
        }

        public Error FormatError(string value, string contentType) {
            return this.FormatResult<Error>(value, contentType);
        }

        private class ParameterRegisterer : IParameterRegisterer {
            public ParameterRegisterer() {
                ParametersPost = new Dictionary<string, string>();
                ParametersGet = new Dictionary<string, string>();
            }

            public IDictionary<string, string> ParametersPost { get; private set; }
            public IDictionary<string, string> ParametersGet { get; private set; }
            public string PostContent { get; private set; }

            public void RegisterGet(string name, string value) {
                if (!string.IsNullOrEmpty(value)) {
                    this.ParametersGet.Add(name, System.Uri.EscapeDataString(value));
                }
            }

            public void RegisterPost(string name, string value) {
                if (!string.IsNullOrEmpty(value)) {
                    this.ParametersPost.Add(name, System.Uri.EscapeDataString(value));
                }
            }

            public IDictionary<string, string> GetAllParameters() {
                return this.ParametersGet
                    .Union(this.ParametersPost)
                    .OrderBy(pair => pair.Key)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            }

            public void RegisterGet(string name, bool value) {
                this.RegisterGet(name, value.ToString().ToLowerInvariant());
            }

            public void RegisterPost(string name, bool value) {
                this.RegisterPost(name, value.ToString().ToLowerInvariant());
            }

            public void RegisterGet(string name, int? value) {
                if (value.HasValue) {
                    this.RegisterGet(name, value.Value.ToString(CultureInfo.InvariantCulture));
                }
            }

            public void RegisterPost(string name, int? value) {
                if (value.HasValue) {
                    this.RegisterPost(name, value.Value.ToString(CultureInfo.InvariantCulture));
                }
            }

            public void RegisterGet(string name, DateTime? value, string format) {
                if (value.HasValue) {
                    this.RegisterGet(name, value.Value.ToString(format));
                }
            }

            public void RegisterPost(string name, DateTime? value, string format) {
                if (value.HasValue) {
                    this.RegisterPost(name, value.Value.ToString(format));
                }
            }

            private static IDictionary<JsonMode, DefaultContractResolver> Converters = new Dictionary<JsonMode, DefaultContractResolver> {
                {
                    JsonMode.LowerHyphen, new LinkedInJsonConverter()
                }
            };

            public void RegisterPostContent(dynamic value) {
                var settings = new JsonSerializerSettings {
                    ContractResolver = Converters[this.PostContentMode],
                    StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                };

                this.PostContent = JsonConvert.SerializeObject(value, settings);
            }

            protected virtual JsonMode PostContentMode {
                get {
                    return JsonMode.LowerHyphen;
                }
            }

            protected enum JsonMode {
                LowerHyphen,
            }
        }
    }
}
