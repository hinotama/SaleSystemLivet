using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaleSystemLivet.Services
{
    public class AuthService
    {
        private readonly CommonService commonServices = new CommonService();
        private readonly string apiControllerUrl = "/Auth";

        public HttpResponseMessage Login(string username, string password)
        {
            // Create a JSON body to send with the request to the API.
            string jsonBody = "{'Username': '" + username + "', 'Password': '" + password + "'}";

            // Create API URL and call it to get response with json body (pass "LOGIN" string as method to check).
            return commonServices.HttpRequest(HttpMethod.Post, apiControllerUrl + "/Login", jsonBody);
        }
    }
}
