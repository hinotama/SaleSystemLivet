using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleSystemAPI.Repositories.Interfaces;
using SaleSystemData.Models;

namespace SaleSystemAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SaleSystemDBContext _context;

        public AuthRepository(SaleSystemDBContext context)
        {
            _context = context;
        }

        public async Task<int> CheckBearerToken(string bearerToken)
        {
            if (bearerToken != null)
            {
                var checkBearer = bearerToken.Substring(0, 7);
                if (checkBearer.Equals("bearer ", StringComparison.InvariantCultureIgnoreCase))
                {
                    Auth auth = await CheckTokenExist(bearerToken.Substring(7));
                    if (auth != null)
                    {
                        DateTime expiration = auth.Expiration ?? DateTime.Now;
                        int compareDate = DateTime.Compare(expiration, DateTime.Now);
                        if (compareDate > 0)
                        {
                            // Ok, authorized (200)
                            return 0;
                        }
                        // Unauthorized, token expired (401)
                        return 1;
                    }
                    // Forbidden, token not exist in the db (403)
                    return 2;
                }
                // Precondition failed, header not correctly typed as "bearer" (412)
                return 3;
            }
            // Bad request, no header (400)
            return 4;
        }

        public async Task<User> CheckLogin(string username, string password)
        {
            if (_context != null)
            {
                return await(from u in _context.User
                             where u.Username == username
                             && u.Password == password
                             select new User
                             {
                                 UserId = u.UserId,
                                 Username = u.Username,
                                 Password = u.Password
                             }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<Auth> CheckTokenExist(string token)
        {
            if (_context != null)
            {
                return await (from a in _context.Auth
                             where a.Token == token
                             select new Auth
                             {
                                 AuthId = a.AuthId,
                                 Token = a.Token,
                                 Expiration = a.Expiration,
                                 UserId = a.UserId
                             }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<int> AddToken(Auth auth)
        {
            if (_context != null)
            {
                await _context.Auth.AddAsync(auth);
                await _context.SaveChangesAsync();

                return auth.AuthId;
            }
            return 0;
        }
    }
}
