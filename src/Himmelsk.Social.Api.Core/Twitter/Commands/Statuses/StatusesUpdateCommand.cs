using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;

namespace Himmelsk.Social.Api.Core.Twitter.Commands.Statuses {
    class StatusesUpdateCommand : AbstractTwitterCommand<string> {
        public string Status { get; set; }

        public override CommandVerb Verb {
            get { return CommandVerb.Post; }
        }

        public override void RegisterParameters(IParameterRegisterer registerer) {
            registerer.RegisterPost("status", this.Status);
        }

        public override string BaseUrl {
            get { return "https://api.twitter.com/1.1/statuses/update.json"; }
        }
    }
}
