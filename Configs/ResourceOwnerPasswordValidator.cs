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

namespace AuthSSO.Configs
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            AppDbContext _appContext = new AppDbContext();

            SysAppusers user = _appContext.SysAppusers.Where(user => user.Username == context.UserName && user.Passwd == context.Password).FirstOrDefault();

            Console.WriteLine(context.ToString());

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
            // claims.Add(new Claim("username", user.SysApproles));
            foreach (var roles in user.SysApproles)
            {
                claims.Add(new Claim("roles", roles.Rolename));
            }
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