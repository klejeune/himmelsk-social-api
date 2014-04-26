using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;
using Himmelsk.Social.Api.Core.Twitter.Results;

namespace Himmelsk.Social.Api.Core.Twitter.Commands.Followers {
    class FollowerIdsCommand : AbstractTwitterCommand<UserIdListResult> {
        public string ScreenName { get; set; }

        public override CommandVerb Verb {
            get { return CommandVerb.Get; }
        }

        public override void RegisterParameters(IParameterRegisterer registerer) {
            registerer.RegisterGet("screen_name", this.ScreenName);
        }

        public override string BaseUrl {
            get { return "https://api.twitter.com/1.1/followers/ids.json"; }
        }
    }
}
