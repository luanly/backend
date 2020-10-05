using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Infrastructure.Extensions;
using Identity.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Identity.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services
			   .AddDatabaseConfiguration(Configuration.GetConnectionString("DefaultConnection"))
			   .AddIdentityServerConfig(Configuration)
			   .AddServices<AppUser>();

			services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
			  .AllowAnyMethod()
			  .AllowAnyHeader()));

			services.AddControllersWithViews();
			services.AddRazorPages();
			services.AddMvc(options =>
			{
				options.EnableEndpointRouting = false;
			}).SetCompatibilityVersion(CompatibilityVersion.Latest);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			app.UseCors("AllowAll");
			app.UseIdentityServer();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					 name: "default",
					 template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}