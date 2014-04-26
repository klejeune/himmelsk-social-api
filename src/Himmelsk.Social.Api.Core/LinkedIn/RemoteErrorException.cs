using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelsk.Social.Api.Core.LinkedIn {
    public class RemoteErrorException : Exception {
        public RemoteErrorException(string message)
            : base(message) {

        }
    }
}
