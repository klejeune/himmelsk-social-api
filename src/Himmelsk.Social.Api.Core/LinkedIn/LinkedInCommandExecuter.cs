using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;

namespace Himmelsk.Social.Api.Core.LinkedIn {
    class LinkedInCommandExecuter : BaseCommandExecuter<ILinkedInCredentials> {
        protected override void AddHeader<TResult>(ILinkedInCredentials credentials, ICommand<TResult> command, HttpWebRequest request) {
            base.AddHeader(credentials, command, request);

            var verb = request.Method;

            var authorization = credentials.GetAuthorization(verb, command.BaseUrl, this.GetAllParameters(command));
            request.Headers.Add("Authorization", authorization);
        }
    }
}
