using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelsk.Social.Api.Core.LinkedIn.Results {
    class Result<TResult> : IResult<TResult> {
        public TResult Typed { get; set; }
        public string Raw { get; set; }
    }
}
