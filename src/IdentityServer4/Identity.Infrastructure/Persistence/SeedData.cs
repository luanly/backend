using IdentityModel;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Identity.Infrastructure.Persistence
{
	public class SeedData
	{
		public static void EnsureSeedData(IServiceProvider provider)
		{
			provider.GetRequiredService<AppIdentityDbContext>().Database.Migrate();
			provider.GetRequiredService<AppPersistedGrantDbContext>().Database.Migrate();
			provider.GetRequiredService<AppConfigurationDbContext>().Database.Migrate();

			var context = provider.GetRequiredService<AppConfigurationDbContext>();
			if (!context.Clients.Any())
			{
				var clients = new List<Client>()
				{
					new Client()
					{
						ClientName = "portal-resource",
						ClientId = "client",
						AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
						RequirePkce = true,
						AllowOfflineAccess = true,
						RequireClientSecret = false,
						RedirectUris = {"http://localhost:3000/signin-oidc" },
						AllowedCorsOrigins = {"http://localhost:3000"},
						PostLogoutRedirectUris = { "http://localhost:3000" },
						Enabled = true,
						AllowAccessTokensViaBrowser = true,
						AllowedScopes = { "api", "video", "openid", "profile", "offline_access" }
					},
					new Client()
					{
						ClientName = "video-resource",
						ClientId = "client2",
						RequireClientSecret = false,
						RedirectUris = {"http://localhost:3000/signin-oidc" },
						AllowedCorsOrigins = {"http://localhost:3000"},
						PostLogoutRedirectUris = { "http://localhost:3000" },
						AllowedGrantTypes = GrantTypes.Implicit,
						AllowAccessTokensViaBrowser = true,
						//ClientSecrets =
						//{
						//new Secret("Ud1akUQ/Vo4WOrVOF0WmYnf7lesN5H96ijxAXURVLos=")
						//},
						Description = "portal",
						AllowedScopes = { "api", "video", "openid", "profile", "offline_access" }
					}
				};
				foreach (var client in clients)
				{
					context.Clients.Add(client.ToEntity());
				}
				context.SaveChanges();
			}
			if (!context.ApiResources.Any())
			{
				var apiResources = new List<ApiResource>()
				{
					new ApiResource("api")
					{
						Name = "api",
						Description="Description for api resource",
						DisplayName = "API Resource",
					},

					new ApiResource("video")
					{
						Name = "video",
						Description="Description for video resource",
						DisplayName = "VIDEO Resource",
					}
				};

				foreach (var apiResource in apiResources)
				{
					context.ApiResources.Add(apiResource.ToEntity());
				}

				context.SaveChanges();
			}
			if (!context.IdentityResources.Any())
			{
				var identityResources = new List<IdentityResource>()
				{
					new IdentityResources.OpenId(),
					new IdentityResources.Profile(),
				};

				foreach (var identityResource in identityResources)
					context.IdentityResources.Add(identityResource.ToEntity());

				context.SaveChanges();
			}


			using (var scope = provider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var identityContext = scope.ServiceProvider.GetService<AppIdentityDbContext>();
				identityContext.Database.Migrate();

				var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
				var alice = userMgr.FindByNameAsync("alice").Result;
				if (alice == null)
				{
					alice = new AppUser
					{
						Id = Guid.NewGuid().ToString(),
						UserName = "alice",
						Name = "Alice",
						Email = "AliceSmith@email.com"
					};
					var result = userMgr.CreateAsync(alice, "Pass123$").Result;
					if (!result.Succeeded)
					{
						throw new Exception(result.Errors.First().Description);
					}

					result = userMgr.AddClaimsAsync(alice, new Claim[]{
						new Claim(JwtClaimTypes.Name, "Alice Smith"),
						new Claim(JwtClaimTypes.GivenName, "Alice"),
						new Claim(JwtClaimTypes.FamilyName, "Smith"),
						new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
						new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
						new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
						new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
					}).Result;
					if (!result.Succeeded)
					{
						throw new Exception(result.Errors.First().Description);
					}
					Log.Debug("alice created");
				}
				else
				{
					Log.Debug("alice already exists");
				}

				var bob = userMgr.FindByNameAsync("bob").Result;
				if (bob == null)
				{
					bob = new AppUser
					{
						Id = Guid.NewGuid().ToString(),
						UserName = "bob",
						Name = "Bob",
						Email = "BobSmith@email.com"
					};
					var result = userMgr.CreateAsync(bob, "Pass123$").Result;
					if (!result.Succeeded)
					{
						throw new Exception(result.Errors.First().Description);
					}

					result = userMgr.AddClaimsAsync(bob, new Claim[]{
						new Claim(JwtClaimTypes.Name, "Bob Smith"),
						new Claim(JwtClaimTypes.GivenName, "Bob"),
						new Claim(JwtClaimTypes.FamilyName, "Smith"),
						new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
						new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
						new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
						new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
						new Claim("location", "somewhere")
					}).Result;
					if (!result.Succeeded)
					{
						throw new Exception(result.Errors.First().Description);
					}
					Log.Debug("bob created");
				}
				else
				{
					Log.Debug("bob already exists");
				}
			}
		}
	}
}
