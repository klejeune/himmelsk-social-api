using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;
using Newtonsoft.Json;

namespace Himmelsk.Social.Api.Core.Twitter.Commands {
    abstract class AbstractTwitterCommand<TResult> : AbstractCommand<TResult> where TResult : class {
        protected override JsonSerializerSettings CreateJsonSettings() {
            var settings = base.CreateJsonSettings();
            settings.ContractResolver = new LibCamelCaseContractResolver();

            return settings;
        }
    }
}
