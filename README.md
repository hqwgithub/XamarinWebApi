# XamarinWebApi

Plugin for Xamarin Accessing WebApi Web Api

This plugin is to ease developer to access web api in xamarin. You can send request, receive response and extract cookies from web api.

Note: All of your projects under a solution must be using Xamarin Forms 3.3.0.912540 or later
All projects must be using the same version of Xamarin Forms if not, there will be token error

After installing the plugin into your project from nuget: 

1) Study the web api request in JSON format. For example:
{
  "UserName": "karim@mail.com",
  "UserAgentCode": null,
  "ManufacturerCode": null,
  "AuthenticationToken": null,
  "DeviceId": null,
  "RequestTrxId": "",
  "RequestRetryNo": "",
  "AppVersion": null,
  "RequestObject": {
    "Username": "karim@mail.com",
    "Password": "Abc@12345"
  }
}

2) Create two classes that reflect the JSON structure for web api request. For example:

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
    
public class WS_LoginUser
    {
        public string Username;
        public string Password;
    }
    
  3) If you want to format the response from JSON and extract into any class, study the JSON format of the response first, for example:
  
  {
    "RequestUserName": "karim@mail.com",
    "RequestDeviceId": null,
    "RequestTrxId": 0,
    "RequestRetryNo": 0,
    "RequestAppVersion": null,
    "ResponseStatus": "S",
    "ResponseErrorNo": null,
    "ResponseErrorDetail": null,
    "AuthenticationToken": null,
    "ResponseTrxId": 0,
    "ResponseMessage": "User karim@mail.com successfully login.",
    "ResponseValue": 0
}

4) Create a class that reflects JSON structure of the response, for example:

public class WS_ResponseHeader
    {
        public object ResponseObject;
        public object RequestUserName;
        public object RequestDeviceId;
        public object RequestTrxId;
        public object RequestRetryNo;
        public object RequestAppVersion;
        public object ResponseStatus;
        public object ResponseErrorNo;
        public object ResponseErrorDetail;
        public object AuthenticationToken;
        public object ResponseTrxId;
        public object ResponseMessage;
        public object ResponseValue;
    }
    
5) Once done, insert function below to any page that needs to access the web api:

 public async void accessWebApi()
        {
            WS_LoginUser wsLoginDetails = new WS_LoginUser();
            wsLoginDetails.Username = "karim@mail.com";
            wsLoginDetails.Password = "Abc@12345";

            WS_RequestHeaderLogin wsReqHeader = new WS_RequestHeaderLogin();
            wsReqHeader.UserName = wsLoginDetails.Username;
            wsReqHeader.RequestObject = wsLoginDetails;

            try
            {
                //string responseStr = await Task.Factory.StartNew(XamWebApi.AccessWebApiAsync, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);

                //access and getting response from webApi
                //XamWebApi.AccessWebApiAsync(<base url>, <timeout in seconds>, <web api url>, <request header class>)
                string responseStr = await XamWebApi.AccessWebApiAsync("http://mychoiceforlife.121advisor.com/", 30, "http://mychoiceforlife.121advisor.com/edfapi/user/login", wsReqHeader);

                //convert response from JSON to class WS_ResponseHeader, these lines is optional
                WS_ResponseHeader responseObject = new WS_ResponseHeader();
                if (responseStr != "")
                {
                    object jsonTest = JsonConvert.DeserializeObject(responseStr);
                    responseObject = JsonConvert.DeserializeObject<WS_ResponseHeader>(responseStr);                    
                }

                //retrieve all cookies from webApi
                foreach (Cookie cookie in XamWebApi.cookieCollection)
                {
                    string cookieName = cookie.Name;
                    string cookieValue = cookie.Value;

                    if (cookieName == ".ASPXFORMSAUTH") //search cookie by name
                    {

                    }
                }

                var check = "";
            }
            catch(Exception ex)
            {
                var exMsg = ex.InnerException.Message;
            }
            
        }
        
        6) Please have a look at the sample code here: https://github.com/magiciangambit/XamarinWebApi/
