using Himmelsk.Social.Api.Core.LinkedIn.Commands;
using Himmelsk.Social.Api.Core.LinkedIn.Commands.Companies;
using Himmelsk.Social.Api.Core.LinkedIn.Commands.Companies.Parameters;
using Himmelsk.Social.Api.Core.LinkedIn.Results;
using Himmelsk.Social.Api.Core.LinkedIn.Results.Companies;
using Himmelsk.Social.Api.Core.LinkedIn.Results.People;

namespace Himmelsk.Social.Api.Core.LinkedIn.UserFriendly {
    class LinkedInCommands : ILinkedInCompaniesCommands, ILinkedInPeopleCommands {
        private readonly ICommandExecuter<ILinkedInCredentials> executer;

        public LinkedInCommands(ICommandExecuter<ILinkedInCredentials> executer) {
            this.executer = executer;
        }

        public IResult<CompanyUpdates> GetUpdates(ILinkedInCredentials credentials, string companyId) {
            return this.executer.Execute(credentials, new GetCompanyUpdates(companyId));
        }

        public IResult<ShareResult> Share(
            ILinkedInCredentials credentials, string companyId, ShareVisibility visibility, string comment) {
            return this.executer.Execute(
                credentials, new CompanyShare {
                    CompanyId = companyId,
                    Visibility = visibility,
                    Comment = comment,
                });
        }

        public IResult<ShareResult> Share(
            ILinkedInCredentials credentials, string companyId, ShareVisibility visibility, string comment,
            string submittedUrl, string title, string description, string submittedImageUrl) {
            return this.executer.Execute(
                credentials, new CompanyShare {
                    CompanyId = companyId,
                    Visibility = visibility,
                    Comment = comment,
                    SubmittedUrl = submittedUrl,
                    Title = title,
                    Description = description,
                    SubmittedImageUrl = submittedImageUrl,
                });
        }

        IResult<ShareResult> ILinkedInPeopleCommands.Share(ILinkedInCredentials credentials, ShareVisibility visibility, string comment) {
            return this.executer.Execute(
               credentials, new PeopleShare {
                   Visibility = visibility,
                   Comment = comment,
               });
        }

        IResult<ShareResult> ILinkedInPeopleCommands.Share(ILinkedInCredentials credentials, ShareVisibility visibility, string comment, string submittedUrl, string title, string description, string submittedImageUrl) {
            return this.executer.Execute(
                credentials, new PeopleShare {
                    Visibility = visibility,
                    Comment = comment,
                    SubmittedUrl = submittedUrl,
                    Title = title,
                    Description = description,
                    SubmittedImageUrl = submittedImageUrl,
                });
        }

        IResult<ShareResult> ILinkedInPeopleCommands.Share(ILinkedInCredentials credentials, ShareVisibility visibility, string submittedUrl, string title, string description, string submittedImageUrl) {
            return this.executer.Execute(
                credentials, new PeopleShare {
                    Visibility = visibility,
                    SubmittedUrl = submittedUrl,
                    Title = title,
                    Description = description,
                    SubmittedImageUrl = submittedImageUrl,
                });
        }
    }
}
