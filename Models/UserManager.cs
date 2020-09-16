

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace AuthSSO.Models
{
    public class UserManager : IUserManager
    {
        private AppDbContext context;

        public UserManager()
        {
        }

        public UserManager(AppDbContext context)
        {
            this.context = context;
        }

        public bool Validate()
        {
            return true;
        }

        public async Task SignIn(HttpContext httpContext, SysAppusers user, bool isPersistent = false)
        {
            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties() { IsPersistent = isPersistent }
            );
        }

        public Task SignIn(HttpContext httpContext, SysAppusers user)
        {
            throw new System.NotImplementedException();
        }

        private IEnumerable<Claim> GetUserClaims()
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, "1"));
            claims.Add(new Claim(ClaimTypes.Name, "Thong"));
            claims.AddRange(this.GetUserRoles());

            return claims;
        }

        private IEnumerable<Claim> GetUserRoles()
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            return claims;
        }
    }
}