using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himmelsk.Social.Api.Core.LinkedIn.Commands {
    interface IParameterRegisterer {
        void RegisterGet(string name, string value);
        void RegisterGet(string name, bool value);
        void RegisterGet(string name, int? value);
        void RegisterGet(string name, DateTime? value, string format);
        void RegisterPost(string name, string value);
        void RegisterPost(string name, bool value);
        void RegisterPost(string name, int? value);
        void RegisterPost(string name, DateTime? value, string format);
        void RegisterPostContent(dynamic value);

        IDictionary<string, string> ParametersPost { get; }
        IDictionary<string, string> ParametersGet { get; }
        string PostContent { get; }
    }
}
