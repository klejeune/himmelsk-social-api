using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;

namespace Himmelsk.Social.Api.Core.Facebook {
    public interface IFacebookCredentials : ICredentials {
        string AppId { get; }
        string AppSecret { get; }
        string AccessToken { get; }
    }
}
