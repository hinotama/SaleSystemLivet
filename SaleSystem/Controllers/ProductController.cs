using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaleSystemAPI.Repositories;
using SaleSystemAPI.Services.Interfaces;
using SaleSystemData.Models;

namespace SaleSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IProductService _productService;
        private readonly IConfiguration _configuration;

        public ProductController(IAuthService authService, IProductService productService, IConfiguration configuration)
        {
            _authService = authService;
            _productService = productService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            // Get bearer token from the request sent to the API and then check it.
            var bearerToken = Request.Headers["Authorization"].ToString();
            int checkBearerToken = await _authService.CheckBearerToken(bearerToken);
            switch (checkBearerToken)
            {
                case 0: // Ok, authorized
                    // Set return message which will be returned to the client.
                    string returnMessage = "Validation Message:";
                    // Set return flag to check if validation is success or not.
                    bool returnFlag = false;
                    // Validate Product input fields sent from the client.
                    if (string.IsNullOrEmpty(product.ProductName))
                    {
                        returnMessage += Environment.NewLine + "- Product must not be empty.";
                        returnFlag = true;
                    }
                    if (string.IsNullOrEmpty(product.Description))
                    {
                        returnMessage += Environment.NewLine + "- Description must not be empty.";
                        returnFlag = true;
                    }
                    if (string.IsNullOrEmpty(product.Unit))
                    {
                        returnMessage += Environment.NewLine + "- Unit must not be empty.";
                        returnFlag = true;
                    }
                    // If even one of them failed the validation, return error message.
                    if (returnFlag)
                    {
                        return StatusCode(412, returnMessage);
                    }
                    // Else, add the Product to the database.
                    var addProduct = await _productService.AddProduct(product);
                    if (addProduct != 0)
                    {
                        // Return OK if added sucessfully.
                        return StatusCode(200, "New Product added sucessfully.");
                    }
                    // Return server error if added unsucessfully.
                    return StatusCode(500, "For some reasons, new Product can't be added.");
                case 1: // Unauthorized, token expired
                    return StatusCode(401, "Token expired");
                case 2: // Forbidden, token not exist in the db
                    return StatusCode(403, "Token not exist in the db");
                case 3: // Precondition failed, header not correctly typed as "bearer"
                    return StatusCode(412, "Header not correctly typed as \"bearer\"");
                case 4: // Bad request, no header
                    return StatusCode(400, "No header");
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("EditProduct")]
        public async Task<IActionResult> EditProduct([FromBody] Product product)
        {
            // Get bearer token from the request sent to the API and then check it.
            var bearerToken = Request.Headers["Authorization"].ToString();
            int checkBearerToken = await _authService.CheckBearerToken(bearerToken);
            switch (checkBearerToken)
            {
                case 0: // Ok, authorized
                    // Set return message which will be returned to the client.
                    string returnMessage = "Validation Message:";
                    // Set return flag to check if validation is success or not.
                    bool returnFlag = false;
                    // Validate Product input fields sent from the client.
                    if (string.IsNullOrEmpty(product.ProductName))
                    {
                        returnMessage += Environment.NewLine + "- Product must not be empty.";
                        returnFlag = true;
                    }
                    if (string.IsNullOrEmpty(product.Description))
                    {
                        returnMessage += Environment.NewLine + "- Description must not be empty.";
                        returnFlag = true;
                    }
                    if (string.IsNullOrEmpty(product.Unit))
                    {
                        returnMessage += Environment.NewLine + "- Unit must not be empty.";
                        returnFlag = true;
                    }
                    // If even one of them failed the validation, return error message.
                    if (returnFlag)
                    {
                        return StatusCode(412, returnMessage);
                    }
                    // Else, update the Product in the database with this Product data.
                    var editProduct = await _productService.EditProduct(product);
                    if (editProduct != 0)
                    {
                        // Return OK if added sucessfully.
                        return StatusCode(200, "Product edited sucessfully.");
                    }
                    // Return server error if added unsucessfully.
                    return StatusCode(500, "For some reasons, this Product can't be edited.");
                case 1: // Unauthorized, token expired
                    return StatusCode(401, "Token expired");
                case 2: // Forbidden, token not exist in the db
                    return StatusCode(403, "Token not exist in the db");
                case 3: // Precondition failed, header not correctly typed as "bearer"
                    return StatusCode(412, "Header not correctly typed as \"bearer\"");
                case 4: // Bad request, no header
                    return StatusCode(400, "No header");
            }
            return Unauthorized();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            // Get bearer token from the request sent to the API and then check it.
            var bearerToken = Request.Headers["Authorization"].ToString();
            int checkBearerToken = await _authService.CheckBearerToken(bearerToken);
            switch (checkBearerToken)
            {
                case 0: // Ok, authorized
                    // Delete Product data by productId.
                    var deleteProduct = await _productService.DeleteProduct(productId);
                    if (deleteProduct != 0)
                    {
                        // Return status success with the message to the requested client.
                        return StatusCode(200, "Product deleted successfully.");
                    }
                    // Return server error if added unsucessfully.
                    return StatusCode(500, "For some reasons, this Product can't be deleted.");
                case 1: // Unauthorized, token expired
                    return StatusCode(401, "Token expired");
                case 2: // Forbidden, token not exist in the db
                    return StatusCode(403, "Token not exist in the db");
                case 3: // Precondition failed, header not correctly typed as "bearer"
                    return StatusCode(412, "Header not correctly typed as \"bearer\"");
                case 4: // Bad request, no header
                    return StatusCode(400, "No header");
            }
            return Unauthorized();
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            // Get bearer token from the request sent to the API and then check it.
            var bearerToken = Request.Headers["Authorization"].ToString();
            int checkBearerToken = await _authService.CheckBearerToken(bearerToken);
            switch (checkBearerToken)
            {
                case 0: // Ok, authorized
                    // Get Product data by productId.
                    Product product = await _productService.GetProduct(productId);
                    // Return status success with the Product data to the requested client.
                    return StatusCode(200, product);
                case 1: // Unauthorized, token expired
                    return StatusCode(401, "Token expired");
                case 2: // Forbidden, token not exist in the db
                    return StatusCode(403, "Token not exist in the db");
                case 3: // Precondition failed, header not correctly typed as "bearer"
                    return StatusCode(412, "Header not correctly typed as \"bearer\"");
                case 4: // Bad request, no header
                    return StatusCode(400, "No header");
            }
            return Unauthorized();
        }
        
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            // Get bearer token from the request sent to the API and then check it.
            var bearerToken = Request.Headers["Authorization"].ToString();
            int checkBearerToken = await _authService.CheckBearerToken(bearerToken);
            switch (checkBearerToken)
            {
                case 0: // Ok, authorized
                    // Get Product List.
                    var productList = await _productService.GetProducts();
                    // Return status success with the Product List data to the requested client.
                    return StatusCode(200, productList);
                case 1: // Unauthorized, token expired
                    return StatusCode(401, "Token expired");
                case 2: // Forbidden, token not exist in the db
                    return StatusCode(403, "Token not exist in the db");
                case 3: // Precondition failed, header not correctly typed as "bearer"
                    return StatusCode(412, "Header not correctly typed as \"bearer\"");
                case 4: // Bad request, no header
                    return StatusCode(400, "No header");
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("GetProducts/_page={currentPage}&_limit={pageSize}")]
        public async Task<IActionResult> GetProducts(int pageSize, int currentPage)
        {
            // Get bearer token from the request sent to the API and then check it.
            var bearerToken = Request.Headers["Authorization"].ToString();
            int checkBearerToken = await _authService.CheckBearerToken(bearerToken);
            switch (checkBearerToken)
            {
                case 0: // Ok, authorized
                    // Get Product List.
                    var productList = await _productService.GetProducts(pageSize, currentPage);
                    // Return status success with the Product List data to the requested client.
                    return StatusCode(200, productList);
                case 1: // Unauthorized, token expired
                    return StatusCode(401, "Token expired");
                case 2: // Forbidden, token not exist in the db
                    return StatusCode(403, "Token not exist in the db");
                case 3: // Precondition failed, header not correctly typed as "bearer"
                    return StatusCode(412, "Header not correctly typed as \"bearer\"");
                case 4: // Bad request, no header
                    return StatusCode(400, "No header");
            }
            return Unauthorized();
        }

        //[HttpGet]
        //[Route("GetProducts")]
        //public async Task<IActionResult> GetProducts()
        //{
        //    var productList = await _productService.ListProduct();
        //    return Ok(productList);
        //}
    }
}