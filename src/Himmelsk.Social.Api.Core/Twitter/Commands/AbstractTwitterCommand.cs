using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;

namespace Himmelsk.Social.Api.Core.Twitter.Commands {
    abstract class AbstractTwitterCommand<TResult> : AbstractCommand<TResult> where TResult : class {
    }
}
