using System.IO;
using Data.EntityFramework.EntityFramework;
using IdentityServer4.AccessTokenValidation;
using Infrastructure.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace API
{
	public class Startup
	{
		private readonly IConfigurationRoot configRoot;
		public Startup(IConfiguration configuration)
		{
			Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
			Configuration = configuration;

			IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
			configRoot = builder.Build();
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAuthorization(options =>
			{
				options.AddPolicy("videoPolicy", builder =>
				{
					builder.RequireClaim("scope", "video");
				});

			});

			services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
				.AddIdentityServerAuthentication(options =>
				{
					options.Authority = Configuration["Identity:Authority"];
					options.RequireHttpsMetadata = false;
				});

			services.AddController();

			services.AddDbContext(Configuration, configRoot);

			services.AddAutoMapper();

			services.AddAddScopedServices();

			services.AddSwaggerOpenAPI();

			services.AddMediatorCQRS();

			services.AddUnitOfWork<ApplicationDbContext>();

			services.AddVersion();

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseAuthentication();

			app.UseRouting();

			app.UseAuthorization();

			app.ConfigureCustomExceptionMiddleware();

			app.ConfigureSwagger();

			log.AddSerilog();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

		}
	}
}
