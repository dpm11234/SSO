using System.Collections.Generic;
using IdentityServer4.Models;

namespace AuthSSO
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
          new IdentityResource[]
          {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile()
          };

        public static IEnumerable<ApiScope> ApiScopes =>
          new ApiScope[]
          {
        new ApiScope("api", "This is a api 1"),
        new ApiScope("api_two", "This is a api 2")
          };

        public static IEnumerable<Client> CLients =>
          new Client[]
          {
        // new Client
        // {
        //   RequireConsent= false,
        //   ClientId = "angular_spa",
        //   ClientSecrets = { new Secret("angular_app_secret".Sha256()) },
        //   ClientName = "Angular App",
        //   AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
        //   AllowedScopes = { "openid", "profile", "api" },
        //   AllowedCorsOrigins = {"http://localhost:4200"},
        //   AllowAccessTokensViaBrowser = true,
        //   AccessTokenLifetime = 3600 * 24 * 30 * 12

        // },
        // new Client
        // {
        //   RequireConsent = false,
        //   ClientId = "test",
        //   ClientName = "Test App",
        //   AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
        //   ClientSecrets = { new Secret("client_secret".Sha256()) },
        //   AllowAccessTokensViaBrowser = true,
        //   AllowedScopes = { "openid", "profile", "api" },
        //   AccessTokenLifetime = 3600 * 24 * 30 * 12
        // }, 
        new Client
        {
          RequireConsent = false,
          ClientId = "login",
          ClientName = "Test App",

          AllowedGrantTypes =GrantTypes.ResourceOwnerPassword,
          RedirectUris= {"http://localhost:3001/callback"},
          ClientSecrets = { new Secret("client_secret".Sha256()) },
          AllowAccessTokensViaBrowser = true,
          AllowedScopes = { "openid", "profile", "api" },
          AccessTokenLifetime = 3600 * 24 * 30 * 12
        },
          };
    }
}