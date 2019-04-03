using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Nice2Experience.JwtInfo {

    public static class JwtExtensions {

        public static JwtInformation JwtInformation(this string token)
        {
            var parts = token.Split('.');
            if (parts.Length != 3) return new JwtInformation { Success = false, Message = "Token is not valid" };

            try
            {
                var result = new JwtInformation
                {
                    Header = FromBase64<JwtHeader>(parts[0]),
                    Payload = FromBase64<Dictionary<string, object>> (parts[1]),
                    HashCode = parts[2],
                    Success = true
                };
                // get expiration
                if (result.Payload.ContainsKey("exp"))
                {
                    result.Expires = EpochTime.DateTime((long)result.Payload["exp"]);
                }
                else
                {
                    result.Expires = DateTime.MaxValue;
                }
                return result;
            }
            catch (Exception e)
            {
                return new JwtInformation { Success = false, Message = e.Message };
            }
        }

        private static T FromBase64<T>(string base64String)
        {
            // RFC4648 URL & Filename safe
            var sb = new StringBuilder(base64String);
            sb.Replace('+', '-');
            sb.Replace('_', '/');

            while (sb.Length % 4 != 0) sb.Append('=');
            var bytes = Convert.FromBase64String(sb.ToString());
            var data = Encoding.UTF8.GetString(bytes);
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
            return value;
        }
    }
}