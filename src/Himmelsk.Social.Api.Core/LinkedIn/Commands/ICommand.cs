using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Himmelsk.Social.Api.Core.LinkedIn.Results;

namespace Himmelsk.Social.Api.Core.LinkedIn.Commands {
    public interface ICommand<out TResult> : ICommand {
        TResult FormatResult(string value, string contentType);
    }

    public interface ICommand {
        IEnumerable<IParameter> PostParameters { get; }
        IEnumerable<IParameter> GetParameters { get; }
        string PostContent { get; }
        string BaseUrl { get; }
        CommandVerb Verb { get; }
        string ContentType { get; }
        void AddHeaders(Action<string, string> add);
        Error FormatError(string value, string contentType);
    }
}
