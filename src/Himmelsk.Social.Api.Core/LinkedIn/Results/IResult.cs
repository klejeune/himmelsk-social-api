using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.LinkedIn.Commands;

namespace Himmelsk.Social.Api.Core.LinkedIn.Results {
    public interface IResult<out TResult> {
        TResult Typed { get; }
        string Raw { get; }
    }
}
