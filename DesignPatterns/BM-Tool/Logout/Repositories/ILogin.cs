using Logout.Models;
using Microsoft.AspNetCore.Mvc;

namespace Logout.Repositories
{
    public interface ILogin
    {
        Task  UserLoginCheck(LoginModel user);
    }
}
