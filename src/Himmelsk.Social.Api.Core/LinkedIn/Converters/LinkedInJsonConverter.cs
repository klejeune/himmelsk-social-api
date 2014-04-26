using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Himmelsk.Social.Api.Core.LinkedIn.Converters {
    class LinkedInJsonConverter : DefaultContractResolver {
        public LinkedInJsonConverter()
            : base(true) { }

        protected override string ResolvePropertyName(string propertyName) {
            if (char.IsUpper(propertyName[0])) {
                if (propertyName.Length == 1) {
                    return char.ToLowerInvariant(propertyName[0]).ToString();
                }
                else {
                    return char.ToLowerInvariant(propertyName[0]) + propertyName.Substring(1);
                }
            }

            return propertyName;
        }
    }
}
