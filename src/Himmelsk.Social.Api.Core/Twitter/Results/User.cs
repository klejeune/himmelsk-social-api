using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Himmelsk.Social.Api.Core.Twitter.Results {
    public class User {
        public string IdStr { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool? Protected { get; set; }
        public int? FollowersCount { get; set; }
        public int? FriendsCount { get; set; }
        public int? ListedCount { get; set; }

        [JsonConverter(typeof(TwitterDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }
        public int? FavouritesCount { get; set; }
        public string UtcOffset { get; set; }
        public string TimeZone { get; set; }
        public bool? GeoEnabled { get; set; }
        public bool? Verified { get; set; }
        public int? StatusesCount { get; set; }
        public string Lang { get; set; }
        public bool? ContributorsEnabled { get; set; }
        public bool? IsTranslator { get; set; }
        public bool? IsTranslationEnabled { get; set; }
        public string ProfileBackgroundColor { get; set; }
        public string ProfileBackgroundImageUrl { get; set; }
    }
}
