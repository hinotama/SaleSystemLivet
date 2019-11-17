using Newtonsoft.Json;
using SaleSystemLivet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaleSystemLivet.Services
{
    public class ProductService
    {
        private readonly CommonService commonServices = new CommonService();
        private readonly string apiControllerUrl = "/Product";

        public List<Product> GetProducts()
        {
            // Create API URL and call it to get response without json body (get method).
            HttpResponseMessage response = commonServices.HttpRequest(HttpMethod.Get, apiControllerUrl + "/GetProducts", null);
            string responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data and then return.
                return JsonConvert.DeserializeObject<List<Product>>(responseData);
            }

            MessageBox.Show(responseData, "Response Message");

            return null;
        }

        public List<Product> GetProducts(int pageSize, int currentPage)
        {
            // Create API URL and call it to get response without json body (get method).
            HttpResponseMessage response = commonServices.HttpRequest(HttpMethod.Get, 
                apiControllerUrl + "/GetProducts/_page=" + currentPage + "&_limit=" + pageSize, null);
            string responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data and then return.
                return JsonConvert.DeserializeObject<List<Product>>(responseData);
            }

            MessageBox.Show(responseData, "Response Message");

            return null;
        }

        public Product GetProduct(int productId)
        {
            // Create API URL and call it to get response without json body (get method).
            HttpResponseMessage response = commonServices.HttpRequest(HttpMethod.Get, apiControllerUrl + "/" + productId, null);
            string responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data and then return.
                return JsonConvert.DeserializeObject<Product>(responseData);
            }

            MessageBox.Show(responseData, "Response Message");

            return null;
        }

        public HttpResponseMessage AddProduct(Product product)
        {
            // Create a JSON body to send with the request to the API.
            string jsonBody = "{" +
                    "'ProductName': '" + product.ProductName + "', " +
                    "'Description': '" + product.Description + "', " +
                    "'Price': '" + product.Price + "', " +
                    "'Unit': '" + product.Unit + "', " +
                    "'DeleteFlag': '" + 0 +
                    "'}";

            // Create API URL and call it to get response with json body (post method).
            HttpResponseMessage response = commonServices.HttpRequest(HttpMethod.Post, apiControllerUrl + "/AddProduct", jsonBody);
            string responseData = response.Content.ReadAsStringAsync().Result;
            
            MessageBox.Show(responseData, "Response Message");

            return response;
        }

        public HttpResponseMessage EditProduct(Product product)
        {
            // Create a JSON body to send with the request to the API.
            string jsonBody = "{" +
                    "'ProductId': '" + product.ProductId + "', " +
                    "'ProductName': '" + product.ProductName + "', " +
                    "'Description': '" + product.Description + "', " +
                    "'Price': '" + product.Price + "', " +
                    "'Unit': '" + product.Unit + "', " +
                    "'DeleteFlag': '" + 0 +
                    "'}";

            // Create API URL and call it to get response with json body (post method).
            HttpResponseMessage response = commonServices.HttpRequest(HttpMethod.Post, apiControllerUrl + "/EditProduct", jsonBody);
            string responseData = response.Content.ReadAsStringAsync().Result;
            
            MessageBox.Show(responseData, "Response Message");

            return response;
        }

        public HttpResponseMessage DeleteProduct(int productId)
        {
            // Create API URL and call it to get response without json body (delete method).
            HttpResponseMessage response = commonServices.HttpRequest(HttpMethod.Delete, apiControllerUrl + "/" + productId, null);
            string responseData = response.Content.ReadAsStringAsync().Result;
            
            MessageBox.Show(responseData, "Response Message");

            return response;
        }
    }
}
