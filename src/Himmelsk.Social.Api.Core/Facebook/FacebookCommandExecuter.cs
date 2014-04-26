using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;

namespace Himmelsk.Social.Api.Core.Facebook {
    class FacebookCommandExecuter : BaseCommandExecuter<IFacebookCredentials> {
        protected override string AlterUri<TResult>(IFacebookCredentials credentials, ICommand<TResult> command, string uri) {
            uri = base.AlterUri(credentials, command, uri);

            if (uri.Contains("?")) {
                return uri + "&access_token=" + credentials.AccessToken;
            }
            else {
                return uri + "?access_token=" + credentials.AccessToken;
            }
        }
    }
}
