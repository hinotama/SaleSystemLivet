using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SaleSystemAPI.Services;
using SaleSystemAPI.Services.Interfaces;
using SaleSystemData.Models;

namespace SaleSystemAPI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IAuthService _authService)
        {
            if (!httpContext.Request.Headers.Keys.Contains("Authorization"))
            {
                httpContext.Response.StatusCode = 400; // Bad Request
                await httpContext.Response.WriteAsync("Authorization Key is missing.");
                return;
            }
            var bearerToken = httpContext.Request.Headers["Authorization"].ToString();
            if (bearerToken.Length < 7)
            {
                httpContext.Response.StatusCode = 400; // Bad Request
                await httpContext.Response.WriteAsync("Bearer Token Value is missing.");
                return;
            }
            var checkBearer = bearerToken.Substring(0, 7);
            if (!checkBearer.Equals("bearer ", StringComparison.InvariantCultureIgnoreCase))
            {
                httpContext.Response.StatusCode = 400; // Bad Request
                await httpContext.Response.WriteAsync("Value is not correctly written as a Bearer Token.");
                return;
            }
            Auth auth = await _authService.CheckTokenExist(bearerToken.Substring(7));
            if (auth == null)
            {
                httpContext.Response.StatusCode = 401; // Unauthorized
                await httpContext.Response.WriteAsync("Invalid Token.");
                return;
            }
            DateTime expiration = auth.Expiration ?? DateTime.Now;
            int compareDate = DateTime.Compare(expiration, DateTime.Now);
            if (compareDate <= 0)
            {
                httpContext.Response.StatusCode = 401; // Unauthorized
                await httpContext.Response.WriteAsync("Token expired.");
                return;
            }
            //await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
