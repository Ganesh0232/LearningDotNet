using Microsoft.AspNetCore.Mvc;
using Logout.Repositories;
using Logout.Data;
using Logout.Models;
using Microsoft.EntityFrameworkCore;

namespace Logout.Repositories
{
    public class Login : ILogin
    {
        private readonly IConfiguration configuration;

        public Login(IConfiguration configuration , LoginDbContext logindb)
        {
            this.configuration = configuration;
            Logindb = logindb;
        }

        public LoginDbContext Logindb { get; }

        public async Task UserLoginCheck(LoginModel cred)
        {
          var user = await Logindb.Credentials.FirstOrDefaultAsync(x => x.UserName == cred.UserName);
          var userPassword = await Logindb.Credentials.FirstOrDefaultAsync(y => y.Password == cred.Password);

           
        }
    }
}
