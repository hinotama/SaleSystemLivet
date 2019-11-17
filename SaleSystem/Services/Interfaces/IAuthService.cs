using Microsoft.AspNetCore.Mvc;
using SaleSystemData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystemAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> CheckLogin(string username, string password);

        Task<int> AddToken(Auth auth);

        Task<Auth> CheckTokenExist(string auth);

        Task<int> CheckBearerToken(string bearerToken);
    }
}
