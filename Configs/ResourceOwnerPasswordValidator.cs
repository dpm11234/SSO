using Microsoft.Extensions.Configuration;
using IdentityServer4.Validation;
using System.Security.Claims;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using AuthSSO.Models;
using System.Linq;
using System.Collections.Generic;
using IdentityServer4.Models;
using System;

namespace AuthSSO.Configs
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            // AppDbContext _appContext = new AppDbContext();

            // SysAppusers user = _appContext.SysAppusers.Where(user => user.Username == context.UserName && user.Passwd == context.Password).FirstOrDefault();
            var user = new SysAppusers
            {
                Userid = "abcc",
                Username = "thong",
                Passwd = "password",
                Email = "d@d.com"
            };


            // Console.WriteLine(context.ToString());

            // if (user == null)
            // {
            //     GrantValidationResult result = new GrantValidationResult();
            //     result.Error = "invalid_user";
            //     result.ErrorDescription = "Username or password invalid";
            //     result.IsError = true;

            //     context.Result = result;
            //     return Task.FromResult(0);
            // }

            context.Result = new GrantValidationResult(user.Userid.ToString(), "password", new List<Claim>{
                new Claim("username", user.Username),
                new Claim("email", user.Email),
                // new Claim("roles",),
                new Claim("roles","user"),
            });
            return Task.FromResult(0);

        }
    }
}