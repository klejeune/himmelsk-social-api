using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Twitter.UserFriendly;

namespace Himmelsk.Social.Api.Core.Twitter {
    public interface ITwitterClient {
        ITwitterCredentials GetCredentials(string consumerKey, string consumerSecret, string token, string tokenSecret);
        ITwitterFollowersCommands Followers { get; }
        ITwitterStatusesCommands Statuses { get; }
        ITwitterSearchCommands Search { get; }
        ITwitterApplicationCommands Application { get; }
    }
}
