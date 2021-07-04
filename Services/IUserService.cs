using BookCartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Services
{
   public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);
        Task SignOutAsync();
    }
}
