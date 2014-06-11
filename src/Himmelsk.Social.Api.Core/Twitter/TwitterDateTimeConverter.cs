using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Himmelsk.Social.Api.Core.Twitter {
    class TwitterDateTimeConverter : DateTimeConverterBase {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var dateTime = (DateTime)value;
            var str = dateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK");

            writer.WriteValue(str);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            return DateTime.ParseExact(
                reader.Value.ToString(),
                "ddd MMM dd HH:mm:ss +ffff yyyy",
                CultureInfo.CurrentCulture);
        }
    }
}
