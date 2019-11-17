using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleSystemAPI.Repositories.Interfaces;
using SaleSystemAPI.Services.Interfaces;
using SaleSystemData.Models;

namespace SaleSystemAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<int> AddToken(Auth auth)
        {
            return _authRepository.AddToken(auth);
        }

        public Task<int> CheckBearerToken(string bearerToken)
        {
            return _authRepository.CheckBearerToken(bearerToken);
        }

        public Task<User> CheckLogin(string username, string password)
        {
            return _authRepository.CheckLogin(username, password);
        }

        public Task<Auth> CheckTokenExist(string auth)
        {
            return _authRepository.CheckTokenExist(auth);
        }
    }
}
