using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Himmelsk.Social.Api.Core.LinkedIn.Results.Companies {
    public class CompanyUpdate {
        public long TimeStamp { get; set; }
        public string UpdateKey { get; set; }
        public string UpdateType { get; set; }
        public UpdateContent UpdateContent { get; set; }
        public bool IsCommentable { get; set; }
        public bool IsLikeable { get; set; }
    }
}
