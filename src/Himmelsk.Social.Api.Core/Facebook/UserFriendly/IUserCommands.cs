using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Facebook.Commands.User;
using Himmelsk.Social.Api.Core.LinkedIn.Results;

namespace Himmelsk.Social.Api.Core.Facebook.UserFriendly {
    public interface IUserCommands {
        IResult<IdResult> Share(IFacebookCredentials credentials, string comment);
    }
}
