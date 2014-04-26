using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Facebook.UserFriendly;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;
using Himmelsk.Social.Api.Core.Common;

namespace Himmelsk.Social.Api.Core.Facebook {
    class FacebookClient : IFacebookClient {
        private FacebookCommands facebookCommands;
        private ICommandExecuter<IFacebookCredentials> commandExecuter;
        private FacebookAnonymousCommandExecuter anonymousCommandExecuter;

        public FacebookClient() {
            this.commandExecuter = new FacebookCommandExecuter();
            this.anonymousCommandExecuter = new FacebookAnonymousCommandExecuter();
            this.facebookCommands = new FacebookCommands(this.commandExecuter);
        }

        public IUserCommands User {
            get {
                return this.facebookCommands;
            }
        }

        public IFacebookCredentials GetAppCredentials(string appId, string appSecret) {
            return new FacebookAppCredentials(this.anonymousCommandExecuter, appId, appSecret);
        }
    }
}
