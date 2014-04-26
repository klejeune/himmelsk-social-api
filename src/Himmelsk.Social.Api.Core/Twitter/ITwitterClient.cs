using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelsk.Social.Api.Core.Twitter {
    interface ITwitterClient {
        ITwitterCredentials GetCredentials(string consumerKey, string consumerSecret, string token, string tokenSecret);
    }
}
