using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Facebook.UserFriendly;

namespace Himmelsk.Social.Api.Core.Facebook {
    public interface IFacebookClient {
        IFacebookCredentials GetAppCredentials(string appId, string appSecret);
        IUserCommands User { get; }
    }
}
