using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaQuality.DAL.Models;
using AquaQuality.DAL.Entities;

namespace AquaQuality.DAL.Interfaces
{
    public interface IUserService 
    {
        Task<string> RegisterAsync(RegisterModel model);
        AppUser GetById(int id);
        IEnumerable<AppUser> GetAll();
        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);
        Task<AuthenticationModel> RefreshTokenAsync(string token);
        bool RevokeToken(string token);
    }
}
