using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Himmelsk.Social.Api.Core.LinkedIn.Results.Companies {
    [System.Xml.Serialization.XmlRoot("updates")]
    public class CompanyUpdates {
        public CompanyUpdate[] Values { get; set; }

        [JsonProperty(PropertyName = "_total")]
        public int Total { get; set; }

        [JsonProperty(PropertyName = "_start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "_count")]
        public int Count { get; set; }
    }
}
