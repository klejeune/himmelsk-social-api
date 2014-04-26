using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelsk.Social.Api.Core.LinkedIn.Commands {
    public interface IParameter {
        string Key { get; }
        string Value { get; }
    }
}
