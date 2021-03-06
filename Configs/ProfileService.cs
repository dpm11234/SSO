
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace AuthSSO.Configs
{
  public class ProfileService : IProfileService
  {

    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
      System.Console.WriteLine(context);
      context.IssuedClaims = context.Subject.Claims.ToList();
      return Task.FromResult(0);
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
      return Task.FromResult(0);
    }

  }
}
