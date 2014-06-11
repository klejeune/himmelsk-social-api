using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelsk.Social.Api.Core.Twitter.Results {
    public class RateLimitStatusResult {
        public RateLimitContext RateLimitContext { get; set; }
        public RateLimitResources Resources { get; set; }
    }

    public class RateLimitContext {
        public string AccessToken { get; set; }
    }

    public class RateLimit {
        public int Remaining { get; set; }
        public int Limit { get; set; }
        public long Reset { get; set; }

        public override string ToString() {
            return this.Remaining + " / " + this.Limit + " (reset at " + this.GetReset().ToString("T") + ")";
        }

        public DateTime GetReset() {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(this.Reset);
        }
    }

    public class RateLimitResources {
        public IDictionary<string, RateLimit> Lists { get; set; }
        public IDictionary<string, RateLimit> Application { get; set; }
        public IDictionary<string, RateLimit> Mutes { get; set; }
        public IDictionary<string, RateLimit> Friendships { get; set; }
        public IDictionary<string, RateLimit> Blocks { get; set; }
        public IDictionary<string, RateLimit> Geo { get; set; }
        public IDictionary<string, RateLimit> Users { get; set; }
        public IDictionary<string, RateLimit> Followers { get; set; }
        public IDictionary<string, RateLimit> Statuses { get; set; }
        public IDictionary<string, RateLimit> Help { get; set; }
        public IDictionary<string, RateLimit> Friends { get; set; }
        public IDictionary<string, RateLimit> DirectMessages { get; set; }
        public IDictionary<string, RateLimit> Account { get; set; }
        public IDictionary<string, RateLimit> Favorites { get; set; }
        public IDictionary<string, RateLimit> SavedSearches { get; set; }
        public IDictionary<string, RateLimit> Search { get; set; }
        public IDictionary<string, RateLimit> Trends { get; set; }
    }
}
