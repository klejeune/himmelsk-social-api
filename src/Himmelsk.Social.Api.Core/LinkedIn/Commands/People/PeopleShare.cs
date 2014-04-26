using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;
using Himmelsk.Social.Api.Core.LinkedIn.Commands.Companies.Parameters;
using Himmelsk.Social.Api.Core.LinkedIn.Results.Companies;

namespace Himmelsk.Social.Api.Core.LinkedIn.Results.People {
    class PeopleShare : AbstractLinkedInCommand<ShareResult> {
        public ShareVisibility Visibility { get; set; }
        public string Comment { get; set; }
        public string SubmittedUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubmittedImageUrl { get; set; }

        public override CommandVerb Verb {
            get { return CommandVerb.Post; }
        }

        public override void RegisterParameters(IParameterRegisterer registerer) {
            if (!string.IsNullOrEmpty(this.SubmittedUrl) && !string.IsNullOrEmpty(this.Comment)) {
                registerer.RegisterPostContent(
                    new {
                        visibility = new { code = this.Visibility.GetString() },
                        comment = this.Comment,
                        content = new {
                            submittedUrl = this.SubmittedUrl,
                            title = this.Title,
                            description = this.Description,
                            submittedImageUrl = this.SubmittedImageUrl,
                        }
                    });
            }
            else if (!string.IsNullOrEmpty(this.Comment)) {
                registerer.RegisterPostContent(
                   new {
                       visibility = new { code = this.Visibility.GetString() },
                       comment = this.Comment,
                   });
            }
            else if (!string.IsNullOrEmpty(this.SubmittedUrl)) {
                registerer.RegisterPostContent(
                    new {
                        visibility = new { code = this.Visibility.GetString() },
                        content = new {
                            submittedUrl = this.SubmittedUrl,
                            title = this.Title,
                            description = this.Description,
                            submittedImageUrl = this.SubmittedImageUrl,
                        }
                    });
            }
            else {
                throw new InvalidOperationException("Post must contain 'comment' and/or ('content/title' and 'content/submitted-url'). Max length is 700 characters. ");
            }
        }

        public override string BaseUrl {
            get { return "http://api.linkedin.com/v1/people/~/shares"; }
        }
    }
}
