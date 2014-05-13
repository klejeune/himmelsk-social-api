using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.Twitter.Results;

namespace Himmelsk.Social.Api.Core.Twitter.Commands.Statuses {
    class StatusesHomeTimelineCommand : AbstractTwitterCommand<Tweet[]> {
        public override Common.CommandVerb Verb {
            get { return CommandVerb.Get; }
        }

        public override void RegisterParameters(LinkedIn.Commands.IParameterRegisterer registerer) {
        }

        public override string BaseUrl {
            get { return "https://api.twitter.com/1.1/statuses/home_timeline.json"; }
        }
    }
}
