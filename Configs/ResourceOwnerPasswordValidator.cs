using Microsoft.Extensions.Configuration;
using IdentityServer4.Validation;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using AuthSSO.Models;
using System.Linq;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
namespace AuthSSO.Configs
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            System.Console.WriteLine("hello");
            AppDbContext _appContext = new AppDbContext();

            SysAppusers user = _appContext.SysAppusers.Include(user => user.SysUserandroles)
                                                      .ThenInclude(userAndRoles => userAndRoles.Role)
                                                      //   .Include(user => user.Group)
                                                      //   .ThenInclude(group => group.Groupid)
                                                      .Where(user => user.Username == context.UserName && user.Passwd == context.Password)
                                                      .FirstOrDefault();
            // SysApproles roles = _appContext.SysApproles.Where(roles => roles.Roleid == _appContext.SysUserandroles.Where(ur => ur.Userid == user.Id && ur.Roleid == roles.Roleid).Select(ur => ur.Roleid).FirstOrDefault())
            // Console.WriteLine(context.ToString());
            // System.Console.WriteLine(user.SysUserandroles.Select(x => x.).FirstOrDefault());
            if (user == null)
            {
                GrantValidationResult result = new GrantValidationResult();
                result.Error = "invalid_user";
                result.ErrorDescription = "Username or password invalid";
                result.IsError = true;

                context.Result = result;
                return Task.FromResult(0);
            }

            var claims = new List<Claim>();
            claims.Add(new Claim("email", user.Email));
            claims.Add(new Claim("username", user.Username));
            claims.Add(new Claim("userId", user.Userid));
            // claims.Add(new Claim("username", user.SysApproles));
            foreach (var role in user.SysUserandroles)
            {
                claims.Add(new Claim("roles", role.Role.Rolename));
            }

            claims.Add(new Claim("groupId", user.Groupid.ToString()));

            context.Result = new GrantValidationResult(user.Userid.ToString(), "password", claims);
            //   new System.Collections.Generic.Dictionary<string, object>
            //   {
            //       {"userId", user.Userid},
            //       {"email", user.Email}
            //   });
            // );
            return Task.FromResult(0);

        }
    }
}