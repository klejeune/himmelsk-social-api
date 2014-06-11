using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelsk.Social.Api.Core.Twitter.Results {
    public class TwitterSearchMetadata {
        public long? MaxId { get; set; }
        public long? SinceId { get; set; }
        public string RefreshUrl { get; set; }
        public string NextResults { get; set; }
        public int? Count { get; set; }
        public double? CompletedIn { get; set; }
        public string SinceIdStr { get; set; }
        public string Query { get; set; }
        public string MaxIdStr { get; set; }
    }
}
