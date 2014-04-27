using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelsk.Social.Api.Core.Twitter.Results {
    public class Tweet {
        public bool Favorited { get; set; }
        public bool Truncated { get; set; }
        public DateTime CreatedAt { get; set; }
        public string IdStr { get; set; }
        public string Text { get; set; }
    }
}
