using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Himmelsk.Social.Api.Core.LinkedIn.Results.Companies {
    public class UpdateContent {
        [XmlElement("company")]
        public Company Company { get; set; }
    }
}
