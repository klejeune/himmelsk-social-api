using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.Facebook.Results;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;

namespace Himmelsk.Social.Api.Core.Facebook.Commands {
    class GetAccessTokenCommand : AbstractFacebookCommand<string> {
        public string AppId { get; set; }
        public string AppSecret { get; set; }

        public override CommandVerb Verb {
            get { return CommandVerb.Get; }
        }

        public override void RegisterParameters(LinkedIn.Commands.IParameterRegisterer registerer) {
            registerer.RegisterGet("client_id", this.AppId);
            registerer.RegisterGet("client_secret", this.AppSecret);
            registerer.RegisterGet("grant_type", "client_credentials");
        }

        public override string BaseUrl {
            get { return "https://graph.facebook.com/oauth/access_token"; }
        }
    }
}
