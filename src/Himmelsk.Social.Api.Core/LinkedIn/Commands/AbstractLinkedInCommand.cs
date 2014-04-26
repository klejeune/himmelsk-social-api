using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Himmelsk.Social.Api.Core.LinkedIn.Results;

namespace Himmelsk.Social.Api.Core.LinkedIn.Commands {
    abstract class AbstractLinkedInCommand<TResult> : AbstractCommand<TResult> where TResult : class {
        public override string ContentType { get { return "application/json"; } }

        public override void AddHeaders(Action<string, string> add) {
            add("x-li-format", "json");
        }

        protected override T FormatResult<T>(string value, string contentType) {
            T result;

            if (contentType.StartsWith("application/json")) {
                var settings = new JsonSerializerSettings {
                    ContractResolver = new LinkedInJsonConverter(),
                };

                result = JsonConvert.DeserializeObject<T>(value, settings);
            }
            else if (false) {
                var serializer = new XmlSerializer(typeof (T));

                using (var reader = new StringReader(value)) {
                    result = (T) serializer.Deserialize(reader);
                }
            }
            else {
                throw new InvalidOperationException("Response Content Type not supported: " + contentType);
            }

            return result;
        }
    }
}
