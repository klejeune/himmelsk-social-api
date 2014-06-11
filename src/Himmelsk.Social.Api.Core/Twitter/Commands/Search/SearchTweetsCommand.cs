using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;
using Himmelsk.Social.Api.Core.Twitter.Results;

namespace Himmelsk.Social.Api.Core.Twitter.Commands.Search {
    class SearchTweetsCommand : AbstractTwitterCommand<StatusesResult> {
        public string Query { get; set; }
        public Language? Language { get; set; }
        public TweetsResultType? ResultType { get; set; }
        public int? Count { get; set; }
        public DateTime? Until { get; set; }
        public string SinceId { get; set; }
        public string MaxId { get; set; }
        public bool IncludeEntities { get; set; }

        public override CommandVerb Verb {
            get { return CommandVerb.Get; }
        }

        public override void RegisterParameters(IParameterRegisterer registerer) {
            registerer.RegisterGet("q", this.Query);

            if (this.Language.HasValue) {
                registerer.RegisterGet("lang", this.Language.Value.ToString().ToLower());
            }

            if (this.ResultType.HasValue) {
                registerer.RegisterGet("result_type", this.ResultType.Value.ToString().ToLower());
            }

            if (this.Count.HasValue) {
                registerer.RegisterGet("count", this.Count.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (this.Until.HasValue) {
                registerer.RegisterGet("until", this.Until.Value.ToString("yyyy-MM-dd"));
            }

            if (!string.IsNullOrEmpty(this.SinceId)) {
                registerer.RegisterGet("since_id", this.SinceId);
            }

            if (!string.IsNullOrEmpty(this.MaxId)) {
                registerer.RegisterGet("max_id", this.MaxId);
            }

            registerer.RegisterGet("include_entities", this.IncludeEntities);
        }

        public override string BaseUrl {
            get { return "https://api.twitter.com/1.1/search/tweets.json"; }
        }
    }
}
