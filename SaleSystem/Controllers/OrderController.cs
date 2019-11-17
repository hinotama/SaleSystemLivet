using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaleSystemAPI.Repositories;
using SaleSystemAPI.Services.Interfaces;
using SaleSystemData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;
        private readonly IConfiguration _configuration;

        public OrderController(IAuthService authService, IOrderService orderService, IConfiguration configuration)
        {
            _authService = authService;
            _orderService = orderService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddOrderList")]
        public async Task<IActionResult> AddOrderList([FromBody] List<Order> orderList)
        {
            // Get bearer token from the request sent to the API and then check it.
            var bearerToken = Request.Headers["Authorization"].ToString();
            int checkBearerToken = await _authService.CheckBearerToken(bearerToken);
            switch (checkBearerToken)
            {
                case 0: // Ok, authorized
                    // Check if all rows of the order list is added successfully or not.
                    int orderListCount = 0;
                    int successAddCount = 0;
                    int result = 0;
                    // Loop to add order rows.
                    foreach (Order order in orderList)
                    {
                        orderListCount++;
                        // Add order row.
                        result = await _orderService.AddOrder(order);
                        if (result != 0)
                        {
                            successAddCount++;
                        }
                    }
                    if (orderListCount == successAddCount)
                    {
                        // Return OK if all rows added sucessfully.
                        return StatusCode(200, "Order List added sucessfully.");
                    }
                    // Return server error if added unsucessfully.
                    return StatusCode(500, "For some reasons, this Order List can't be added.");
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
        [Route("ListOrder")]
        public async Task<IActionResult> ListOrder()
        {
            // Get bearer token from the request sent to the API and then check it.
            var bearerToken = Request.Headers["Authorization"].ToString();
            int checkBearerToken = await _authService.CheckBearerToken(bearerToken);
            switch (checkBearerToken)
            {
                case 0: // Ok, authorized
                    // Get Auth data to get user id.
                    Auth auth = await _authService.CheckTokenExist(bearerToken.Substring(7));
                    // Get Product List.
                    var orderList = await _orderService.ListOrder(auth.UserId);
                    // Return status success with the Product List data to the requested client.
                    return StatusCode(200, orderList);
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
    }
}
