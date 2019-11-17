using Newtonsoft.Json;
using SaleSystemLivet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaleSystemLivet.Services
{
    public partial class CommonService
    {
        public string GetApiUrl()
        {
            // Get API URL from the App.config file.
            return ConfigurationManager.AppSettings["SaleSystemAPI"];
        }

        public string GetToken()
        {
            // Get token data from the App.Current.Properties. This works like a global variable.
            //string token;
            //try
            //{
            //    token = Application.Current.Properties["token"].ToString();
            //} catch (Exception e)
            //{
            //    token = "";
            //}
            //return token;
            return "672e52e1-e2c7-492a-a955-aa94107824b3";
        }

        public HttpResponseMessage HttpRequest(HttpMethod method, string apiControllerUrl, string jsonBody)
        {
            // HTTP declarations and settings to connect with the API.
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, GetApiUrl() + apiControllerUrl);

            string token = GetToken();
            if (token != null)
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            if (jsonBody != null)
                httpRequestMessage.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.SendAsync(httpRequestMessage).Result;

            return response;
        }
    }
}
