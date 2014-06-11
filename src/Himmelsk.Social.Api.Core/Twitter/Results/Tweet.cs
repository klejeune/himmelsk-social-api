using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Himmelsk.Social.Api.Core.Twitter.Results {
    public class Tweet {
        public bool Favorited { get; set; }
        public bool Truncated { get; set; }

        [JsonConverter(typeof(TwitterDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        public string IdStr { get; set; }
        public long Id { get; set; }
        public string Text { get; set; }
        public string Source { get; set; }
        public User User { get; set; }

        public override string ToString() {
            return "Tweet n." + this.IdStr + " by " + this.User.ScreenName;
        }
    }
}
