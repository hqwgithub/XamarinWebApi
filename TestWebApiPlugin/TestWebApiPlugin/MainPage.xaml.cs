using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.XamarinWebApi;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace TestWebApiPlugin
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            accessWebApi();

        }

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
	}
}
