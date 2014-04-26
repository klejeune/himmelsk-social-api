using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.LinkedIn.Results;

namespace Himmelsk.Social.Api.Core.Twitter.UserFriendly {
    public interface ITwitterStatusesCommands {
        IResult<string> UpdateStatus(ITwitterCredentials credentials, string status);
    }
}
