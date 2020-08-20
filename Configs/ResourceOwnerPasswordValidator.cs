using Microsoft.Extensions.Configuration;
using IdentityServer4.Validation;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using AuthSSO.Models;
using System.Linq;
using IdentityServer4.Models;

namespace AuthSSO.Configs
{
  public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
  {
    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
      AppDbContext _appContext = new AppDbContext();

      SysAppusers user = _appContext.SysAppusers.Where(user => user.Username == context.UserName).FirstOrDefault();

      if (user == null)
      {
        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, "User name or password invalid");
        return Task.FromResult(0);
      }

      context.Result = new GrantValidationResult(user.Userid.ToString(), "password");
      return Task.FromResult(0);

    }
  }
}