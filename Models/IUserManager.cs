using System.Threading.Tasks;
using AuthSSO.Models;
using Microsoft.AspNetCore.Http;
namespace AuthSSO.Models
{
    public interface IUserManager
    {
        Task SignIn(HttpContext httpContext, SysAppusers user, bool isPersistent = false);

        Task SignIn(HttpContext httpContext, SysAppusers user);
        // int GetCurrentUserId(HttpContext httpContext);
        // int GetCurrentUser(HttpContext httpContext);
    }
}