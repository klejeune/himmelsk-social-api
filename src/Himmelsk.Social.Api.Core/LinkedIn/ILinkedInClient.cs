using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.LinkedIn.UserFriendly;

namespace Himmelsk.Social.Api.Core.LinkedIn {
    public interface ILinkedInClient {
        ILinkedInCredentials GetCredentials(string consumerKey, string consumerSecret, string token, string tokenSecret);
        ILinkedInCompaniesCommands Companies { get; }
        ILinkedInPeopleCommands People { get; }
    }
}
