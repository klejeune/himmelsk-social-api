using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.LinkedIn.Results;
using Himmelsk.Social.Api.Core.Twitter.Results;

namespace Himmelsk.Social.Api.Core.Twitter.UserFriendly {
    public interface ITwitterSearchCommands {
        IResult<StatusesResult> Tweets(ITwitterCredentials credentials, string query, Language? language, TweetsResultType? resultType, int? count, DateTime? until, string sinceId, string maxId, bool includeEntities);
    }
}
