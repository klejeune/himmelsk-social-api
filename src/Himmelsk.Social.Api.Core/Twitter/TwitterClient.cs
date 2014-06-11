using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Twitter.UserFriendly;

namespace Himmelsk.Social.Api.Core.Twitter {
    class TwitterClient : ITwitterClient {
        public TwitterClient() {
            this.commands = new TwitterCommands(new TwitterCommandExecuter());
        }

        public ITwitterCredentials GetCredentials(string consumerKey, string consumerSecret, string token, string tokenSecret) {
            return new TwitterCredentials(consumerKey, consumerSecret, token, tokenSecret);
        }

        private readonly TwitterCommands commands;

        public ITwitterFollowersCommands Followers { get { return this.commands; } }
        public ITwitterStatusesCommands Statuses { get { return this.commands; } }
        public ITwitterApplicationCommands Application { get { return this.commands; } }
        
        public ITwitterSearchCommands Search {
            get { return this.commands; }
        }
    }
}
