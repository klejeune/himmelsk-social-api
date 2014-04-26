using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelsk.Social.Api.Core.Twitter.Results {
    public class UserIdListResult {
        public UserIdListResult() {
            this.Ids = new string[0];
        }

        public string[] Ids { get; set; }
    }
}
