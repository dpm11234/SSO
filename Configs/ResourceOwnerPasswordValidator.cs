using Microsoft.Extensions.Configuration;
using IdentityServer4.Validation;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using AuthSSO.Models;
using System.Linq;
using IdentityServer4.Models;
using System;

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

      context.Result = new GrantValidationResult(user.Userid.ToString(), "password");
      return Task.FromResult(0);

    }
  }
}