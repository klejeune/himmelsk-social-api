﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;

namespace Himmelsk.Social.Api.Core.LinkedIn {
    public interface ILinkedInCredentials : ICredentials {
        string ConsumerKey { get; }
        string ConsumerSecret { get; }
        string Token { get; }
        string TokenSecret { get; }
        string GetAuthorization(string verb, string baseUrl, IDictionary<string, string> parameters);
        string GetAuthorizationCode();
    }
}
