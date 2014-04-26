using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Results.Companies;

namespace Himmelsk.Social.Api.Core.LinkedIn.Commands.Companies {
    class GetCompanyUpdates : AbstractLinkedInCommand<CompanyUpdates> {
        public string CompanyId { get; private set; }

        public GetCompanyUpdates(string companyId) {
            this.CompanyId = companyId;
        }

        public override CommandVerb Verb {
            get { return CommandVerb.Get; }
        }

        public override void RegisterParameters(IParameterRegisterer registerer) {
            
        }

        public override string BaseUrl {
            get { return string.Format("http://api.linkedin.com/v1/companies/{0}/updates", this.CompanyId); }
        }
    }
}
