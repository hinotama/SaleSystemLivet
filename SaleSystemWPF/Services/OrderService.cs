using Newtonsoft.Json;
using SaleSystemWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaleSystemWPF.Services
{
    public class OrderService
    {
        private readonly CommonService commonServices = new CommonService();
        private readonly string apiControllerUrl = "/Order";

        public async Task<HttpResponseMessage> AddOrderList(List<Order> orderList)
        {
            // Create a JSON body to send with the request to the API.
            string jsonBody = "[";
            int count = 0;
            foreach (Order order in orderList)
            {
                count++;
                jsonBody += "{" +
                    "'UserId': " + order.UserId + "," +
                    "'ProductId': " + order.ProductId + "," +
                    "'Quantity': " + order.Quantity +
                    "}";
                if (count < orderList.Count)
                {
                    jsonBody += ",";
                }
            }
            jsonBody += "]";

            // Create API URL and call it to get response with json body (post method).
            HttpResponseMessage response = await commonServices.HttpRequest("POST", apiControllerUrl + "/AddOrderList", jsonBody);
            string responseData = response.Content.ReadAsStringAsync().Result;

            MessageBox.Show(responseData, "Response Message");

            return response;
        }

        public async Task<List<Order>> ListOrder()
        {
            // Create API URL and call it to get response without json body (get method).
            HttpResponseMessage response = await commonServices.HttpRequest("GET", apiControllerUrl + "/ListOrder", null);
            string responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data and then return.
                return JsonConvert.DeserializeObject<List<Order>>(responseData);
            }

            MessageBox.Show(responseData, "Response Message");

            return null;
        }
    }
}
