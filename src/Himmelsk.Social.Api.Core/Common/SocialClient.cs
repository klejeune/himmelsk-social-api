using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Facebook;
using Himmelsk.Social.Api.Core.LinkedIn;

namespace Himmelsk.Social.Api.Core.Common {
    public class SocialClient {
        public IFacebookClient Facebook { get; private set; }
        public ILinkedInClient LinkedIn { get; private set; }

        public SocialClient() {
            this.Facebook = new FacebookClient();
            this.LinkedIn = new LinkedInClient();
        }
    }
}
