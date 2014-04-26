using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Results;

namespace Himmelsk.Social.Api.Core.LinkedIn.Commands {
    interface ICommandExecuter<in TCredentials> where TCredentials : ICredentials {
        IResult<TResult> Execute<TResult>(TCredentials credentials, ICommand<TResult> command);
    }
}
