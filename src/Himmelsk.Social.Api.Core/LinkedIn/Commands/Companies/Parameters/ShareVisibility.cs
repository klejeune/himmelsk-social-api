using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelsk.Social.Api.Core.LinkedIn.Commands.Companies.Parameters {
    public enum ShareVisibility {
        Anyone,
        ConnectionsOnly
    }

    public static class ShareVisibilityExtensions {
        public static string GetString(this ShareVisibility visibility) {
            switch (visibility) {
                case ShareVisibility.Anyone:
                    return "anyone";
                case ShareVisibility.ConnectionsOnly:
                    return "connections-only";
                default:
                    throw new NotImplementedException("Visibility is not supported: " + visibility.ToString());
            }
        }
    }
}
