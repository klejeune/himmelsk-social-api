using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.LinkedIn.Commands.Companies.Parameters;
using Himmelsk.Social.Api.Core.LinkedIn.Results;
using Himmelsk.Social.Api.Core.LinkedIn.Results.Companies;

namespace Himmelsk.Social.Api.Core.LinkedIn.UserFriendly {
    public interface ILinkedInCompaniesCommands {
        IResult<CompanyUpdates> GetUpdates(ILinkedInCredentials credentials, string companyId);

        IResult<ShareResult> Share(
            ILinkedInCredentials credentials, string companyId, ShareVisibility visibility, string comment);

        IResult<ShareResult> Share(
            ILinkedInCredentials credentials, string companyId, ShareVisibility visibility, string comment,
            string submittedUrl, string title, string description, string submittedImageUrl);
    }
}
