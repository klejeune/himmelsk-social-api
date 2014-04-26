using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Himmelsk.Social.Api.Core.Common;

namespace Himmelsk.Social.Api.Core.LinkedIn {
    class LinkedInCredentials : AbstractCredentials, ILinkedInCredentials {
        public string ConsumerKey { get; private set; }

        public string ConsumerSecret { get; private set; }

        public string Token { get; private set; }

        public string TokenSecret { get; private set; }

        public string ForceNonce { get; set; }

        public string ForceTimestamp { get; set; }

        public LinkedInCredentials(string consumerKey, string consumerSecret, string token, string tokenSecret) {
            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;
            this.Token = token;
            this.TokenSecret = tokenSecret;
        }

        private string Sign(string verb, string baseUrl, IDictionary<string, string> parameters) {
            //GS - When building the signature string the params
            //must be in alphabetical order. I can't be bothered
            //with that, get SortedDictionary to do it's thing
            var sd = new SortedDictionary<string, string>(parameters);

            //GS - Build the signature string
            string baseString = String.Empty;
            baseString += verb + "&";
            baseString += Uri.EscapeDataString(baseUrl) + "&";

            foreach (KeyValuePair<string, string> entry in sd) {
                baseString += Uri.EscapeDataString(entry.Key + "=" + entry.Value + "&");
            }

            //GS - Remove the trailing ambersand char, remember 
            //it's been urlEncoded so you have to remove the 
            //last 3 chars - %26
            baseString = baseString.Substring(0, baseString.Length - 3);

            string signingKey = Uri.EscapeDataString(this.ConsumerSecret) + "&" + Uri.EscapeDataString(this.TokenSecret);

            var hasher = new HMACSHA1(new ASCIIEncoding().GetBytes(signingKey));

            string signatureString = Convert.ToBase64String(hasher.ComputeHash(new ASCIIEncoding().GetBytes(baseString)));

            return signatureString;
        }

        public string GetAuthorization(string verb, string baseUrl, IDictionary<string, string> parameters) {
            if (string.IsNullOrEmpty(this.ForceNonce)) {
                this.ForceNonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture)));
            }

            if (string.IsNullOrEmpty(this.ForceTimestamp)) {
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                this.ForceTimestamp = Convert.ToInt64(ts.TotalSeconds).ToString(CultureInfo.InvariantCulture);
            }

            string oauthSignatureMethod = "HMAC-SHA1";
            string oauthVersion = "1.0";

            //GS - When building the signature string the params
            //must be in alphabetical order. I can't be bothered
            //with that, get SortedDictionary to do it's thing
            var sd = new SortedDictionary<string, string>(parameters);

            sd.Add("oauth_version", oauthVersion);
            sd.Add("oauth_consumer_key", this.ConsumerKey);
            sd.Add("oauth_nonce", this.ForceNonce);
            sd.Add("oauth_signature_method", oauthSignatureMethod);
            sd.Add("oauth_timestamp", this.ForceTimestamp);
            sd.Add("oauth_token", this.Token);

            var signature = this.Sign(verb, baseUrl, sd);

            string authorizationHeaderParams = "OAuth ";
            authorizationHeaderParams += "oauth_nonce=" + "\"" + System.Uri.EscapeDataString(this.ForceNonce) + "\", ";
            authorizationHeaderParams += "oauth_signature_method=" + "\"" + System.Uri.EscapeDataString(oauthSignatureMethod) + "\", ";
            authorizationHeaderParams += "oauth_timestamp=" + "\"" + System.Uri.EscapeDataString(this.ForceTimestamp) + "\", ";
            authorizationHeaderParams += "oauth_consumer_key=" + "\"" + Uri.EscapeDataString(this.ConsumerKey) + "\", ";
            authorizationHeaderParams += "oauth_token=" + "\"" + System.Uri.EscapeDataString(this.Token) + "\", ";
            authorizationHeaderParams += "oauth_signature=" + "\"" + System.Uri.EscapeDataString(signature) + "\", ";
            authorizationHeaderParams += "oauth_version=" + "\"" + System.Uri.EscapeDataString(oauthVersion) + "\"";

            return authorizationHeaderParams;
        }

        public string GetAuthorizationCode() {
            throw new NotImplementedException();
        }
    }
}
