using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Facebook.Commands.User;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;
using Himmelsk.Social.Api.Core.Common;

namespace Himmelsk.Social.Api.Core.Facebook.UserFriendly {
    class FacebookCommands : IUserCommands {
        private readonly ICommandExecuter<IFacebookCredentials> executer;

        public FacebookCommands(ICommandExecuter<IFacebookCredentials> executer) {
            this.executer = executer;
        }

        public LinkedIn.Results.IResult<IdResult> Share(IFacebookCredentials credentials, string comment) {
            return this.executer.Execute(
                credentials, new PublishUserFeedCommand {
                    Comment = comment,
                });
        }
    }
}
