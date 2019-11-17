using Newtonsoft.Json;
using SaleSystemWPF.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaleSystemWPF.Services
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
            return Application.Current.Properties["token"].ToString();
        }

        public async Task<HttpResponseMessage> HttpRequest(string method, string apiControllerUrl, string jsonBody)
        {
            // Get API URL from the App.config file.
            string apiUrl = GetApiUrl();

            // HTTP declarations and settings to connect with the API.
            HttpClient httpClient = new HttpClient();
            
            // Check if this is login API call.
            if (!string.Equals(method, "LOGIN", StringComparison.OrdinalIgnoreCase))
            {
                // If this isn't login API call, set request header, adding bearer token.
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", GetToken());
            }
            else
            {
                // If this is login API call, change method to post.
                method = "POST";
            }

            HttpResponseMessage response = null;

            // Check method and call API accordingly.
            if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase))
            {
                response = httpClient.GetAsync(apiUrl + apiControllerUrl).Result;
            }
            else if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase))
            {
                response = await httpClient.PostAsync(apiUrl + apiControllerUrl, 
                    new StringContent(jsonBody, Encoding.UTF8, "application/json"));
            }
            else if (string.Equals(method, "DELETE", StringComparison.OrdinalIgnoreCase))
            {
                response = httpClient.DeleteAsync(apiUrl + apiControllerUrl).Result;
            }

            return response;
        }
    }
}
