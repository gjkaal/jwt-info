using System;
using System.Collections.Generic;

namespace Nice2Experience.JwtInfo {

    public class JwtInformation
    {
        public JwtHeader Header { get; internal set; }
        public Dictionary<string, object> Payload { get; internal set; }
        public string HashCode { get; internal set; }
        public bool Success { get; internal set; }
        public string Message { get; internal set; }
        public DateTime Expires { get; internal set; }
    }
}