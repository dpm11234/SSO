using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AuthSSO.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.Validation;
using IdentityServer4.Services;


namespace AuthSSO
{
  public class Startup
  {
    private readonly IWebHostEnvironment _environment;
    private readonly IConfiguration _configuration;

    public Startup(IWebHostEnvironment environment, IConfiguration configuration)
    {
      _environment = environment;
      _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      // services.AddControllersWithViews();

      services.AddDbContext<AppDbContext>(options =>
      {
        var connectionString = _configuration.GetConnectionString("Default");
        options.UseNpgsql(connectionString);
      });

      services.AddIdentityServer()
        .AddDeveloperSigningCredential()
        .AddInMemoryIdentityResources(Config.IdentityResources)
        .AddInMemoryApiScopes(Config.ApiScopes)
        .AddInMemoryClients(Config.CLients);

      services.AddTransient<IResourceOwnerPasswordValidator, Configs.ResourceOwnerPasswordValidator>();
      services.AddTransient<IProfileService, Configs.ProfileService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      env.IsProduction();


      app.UseRouting();

      app.UseIdentityServer();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapDefaultControllerRoute();
      });
    }
  }
}
