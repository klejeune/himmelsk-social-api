using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.Facebook.Commands;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;

namespace Himmelsk.Social.Api.Core.Facebook {
    class FacebookAppCredentials : AbstractCredentials, IFacebookCredentials {
        private string accessToken;
        private readonly ICommandExecuter<IFacebookEmptyCredentials> commandExecuter;

        public string AppId { get; private set; }
        public string AppSecret { get; private set; }

        public FacebookAppCredentials(ICommandExecuter<IFacebookEmptyCredentials> commandExecuter, string appId, string appSecret) {
            this.AppId = appId;
            this.AppSecret = appSecret;
            this.commandExecuter = commandExecuter;
        }
        
        public string AccessToken {
            get {
                if (string.IsNullOrEmpty(this.accessToken)) {
                    this.GenerateAccessToken();
                }

                return this.accessToken;
            }
        }

        private void GenerateAccessToken() {
            var command = new GetAccessTokenCommand {
                AppId = this.AppId,
                AppSecret = this.AppSecret,
            };

            var result = this.commandExecuter.Execute(new FacebookEmptyCredentials(), command);

            this.accessToken = result.Typed.Substring(13, result.Typed.Length - 13);
        }
    }
}
