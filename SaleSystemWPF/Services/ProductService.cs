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
    public class ProductService
    {
        private readonly CommonService commonServices = new CommonService();
        private readonly string apiControllerUrl = "/Product";

        public async Task<List<Product>> ListProduct()
        {
            // Create API URL and call it to get response without json body (get method).
            HttpResponseMessage response = await commonServices.HttpRequest("GET", apiControllerUrl + "/ListProduct", null);
            string responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data and then return.
                return JsonConvert.DeserializeObject<List<Product>>(responseData);
            }

            MessageBox.Show(responseData, "Response Message");

            return null;
        }

        public async Task<Product> GetProduct(int productId)
        {
            // Create API URL and call it to get response without json body (get method).
            HttpResponseMessage response = await commonServices.HttpRequest("GET", apiControllerUrl + "/" + productId, null);
            string responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data and then return.
                return JsonConvert.DeserializeObject<Product>(responseData);
            }

            MessageBox.Show(responseData, "Response Message");

            return null;
        }

        public async Task<HttpResponseMessage> AddProduct(Product product)
        {
            // Create a JSON body to send with the request to the API.
            string jsonBody = "{" +
                    "'ProductName': '" + product.ProductName + "', " +
                    "'Description': '" + product.Description + "', " +
                    "'Price': '" + product.Price + "', " +
                    "'Unit': '" + product.Unit +
                    "'}";

            // Create API URL and call it to get response with json body (post method).
            HttpResponseMessage response = await commonServices.HttpRequest("POST", apiControllerUrl + "/AddProduct", jsonBody);
            string responseData = response.Content.ReadAsStringAsync().Result;
            
            MessageBox.Show(responseData, "Response Message");

            return response;
        }

        public async Task<HttpResponseMessage> EditProduct(Product product)
        {
            // Create a JSON body to send with the request to the API.
            string jsonBody = "{" +
                    "'ProductId': '" + product.ProductId + "', " +
                    "'ProductName': '" + product.ProductName + "', " +
                    "'Description': '" + product.Description + "', " +
                    "'Price': '" + product.Price + "', " +
                    "'Unit': '" + product.Unit +
                    "'}";

            // Create API URL and call it to get response with json body (post method).
            HttpResponseMessage response = await commonServices.HttpRequest("POST", apiControllerUrl + "/EditProduct", jsonBody);
            string responseData = response.Content.ReadAsStringAsync().Result;
            
            MessageBox.Show(responseData, "Response Message");

            return response;
        }

        public async Task<HttpResponseMessage> DeleteProduct(int productId)
        {
            // Create API URL and call it to get response without json body (delete method).
            HttpResponseMessage response = await commonServices.HttpRequest("DELETE", apiControllerUrl + "/" + productId, null);
            string responseData = response.Content.ReadAsStringAsync().Result;
            
            MessageBox.Show(responseData, "Response Message");

            return response;
        }
    }
}
