using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelsk.Social.Api.Core.Twitter.Results {
    public class StatusesResult {
        public IEnumerable<Tweet> Statuses { get; set; }
        public TwitterSearchMetadata SearchMetadata { get; set; }
    }
}
