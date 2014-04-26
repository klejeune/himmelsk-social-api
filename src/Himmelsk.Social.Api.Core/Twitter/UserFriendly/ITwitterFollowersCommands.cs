using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.LinkedIn.Results;
using Himmelsk.Social.Api.Core.Twitter.Results;

namespace Himmelsk.Social.Api.Core.Twitter.UserFriendly {
    public interface ITwitterFollowersCommands {
        IResult<UserIdListResult> GetFollowerIds(ITwitterCredentials credentials, string username);
    }
}
