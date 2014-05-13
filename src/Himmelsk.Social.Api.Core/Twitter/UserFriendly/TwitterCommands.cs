using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;
using Himmelsk.Social.Api.Core.LinkedIn.Results;
using Himmelsk.Social.Api.Core.Twitter.Commands.Followers;
using Himmelsk.Social.Api.Core.Twitter.Commands.Statuses;

namespace Himmelsk.Social.Api.Core.Twitter.UserFriendly {
    class TwitterCommands : ITwitterFollowersCommands, ITwitterStatusesCommands {
        private readonly ICommandExecuter<ITwitterCredentials> executer;

        public TwitterCommands(ICommandExecuter<ITwitterCredentials> executer) {
            this.executer = executer;
        }

        public LinkedIn.Results.IResult<Results.UserIdListResult> GetFollowerIds(ITwitterCredentials credentials, string username) {
            return this.executer.Execute(
                credentials, new FollowerIdsCommand {
                    ScreenName = username,
                });
        }

        public IResult<string> UpdateStatus(ITwitterCredentials credentials, string status) {
            return this.executer.Execute(
                credentials, new StatusesUpdateCommand {
                    Status = status,
                });
        }

        public IResult<Results.Tweet[]> UserTimeline(ITwitterCredentials credentials, string username) {
            return this.executer.Execute(
                credentials, new StatusesUserTimelineCommand {
                    Username = username
                });
        }

        public IResult<Results.Tweet[]> HomeTimeline(ITwitterCredentials credentials) {
            return this.executer.Execute(
                credentials, new StatusesHomeTimelineCommand {});
        }
    }
}
