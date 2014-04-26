using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.LinkedIn.UserFriendly;
using Himmelsk.Social.Api.Core.Common;

namespace Himmelsk.Social.Api.Core.LinkedIn {
    public class LinkedInClient : ILinkedInClient {
        public LinkedInClient() {
            this.commands = new LinkedInCommands(new LinkedInCommandExecuter());
        }

        public ILinkedInCredentials GetCredentials(string consumerKey, string consumerSecret, string token, string tokenSecret) {
            return new LinkedInCredentials(consumerKey, consumerSecret, token, tokenSecret);
        }

        private readonly LinkedInCommands commands;

        public ILinkedInCompaniesCommands Companies { get { return this.commands; } }
        public ILinkedInPeopleCommands People { get { return this.commands; } }
    }
}
