using System;
using System.Collections.Generic;
using System.Text;

namespace TestWebApiPlugin
{
    public class WS_RequestHeaderLogin
    {
        public string UserName;
        public string UserAgentCode;
        public string ManufacturerCode;
        public string AuthenticationToken;
        public string DeviceId;
        public string RequestTrxId;
        public string RequestRetryNo;
        public string AppVersion;
        public WS_LoginUser RequestObject;
    }
}
