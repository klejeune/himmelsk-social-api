using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;

namespace Himmelsk.Social.Api.Core.Facebook.Commands.User {
    class PublishUserFeedCommand : AbstractFacebookCommand<IdResult> {
        public string Comment { get; set; }

        public override CommandVerb Verb {
            get { return CommandVerb.Post; }
        }

        public override void RegisterParameters(LinkedIn.Commands.IParameterRegisterer registerer) {
            registerer.RegisterGet("message", this.Comment);
        }

        public override string BaseUrl {
            get { return "https://graph.facebook.com/me/feed"; }
        }
    }
}
