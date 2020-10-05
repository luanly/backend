using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using Data.EntityFramework.EntityFramework;
using Infrastructure.Mapping;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Infrastructure.Extension
{
	public static class ConfigureServiceContainer
	{
		public static void AddDbContext(this IServiceCollection serviceCollection,
			 IConfiguration configuration, IConfigurationRoot configRoot)
		{

			serviceCollection.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DevConnection")));

		}

		public static void AddAutoMapper(this IServiceCollection serviceCollection)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});
			IMapper mapper = mappingConfig.CreateMapper();
			serviceCollection.AddSingleton(mapper);
		}

		public static void AddAddScopedServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
		}

		public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddSwaggerGen(setupAction =>
			{
				setupAction.SwaggerDoc(
					"OpenAPISpecification",
					new Microsoft.OpenApi.Models.OpenApiInfo()
					{
						Title = "User API",
						Version = "1",
						Description = "Through this API you can access user details",
						Contact = new Microsoft.OpenApi.Models.OpenApiContact()
						{
							Email = "hoibui@kms-technology.com",
							Name = "Hoi Bui",
						},
						License = new Microsoft.OpenApi.Models.OpenApiLicense()
						{
							Name = "MIT License",
							Url = new Uri("https://opensource.org/licenses/MIT")
						}
					});

				setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer access-token')",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});

				setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						},
			  Scheme = "oauth2",
			  Name = "Bearer",
			  In = ParameterLocation.Header,

			},
			new List<string>()
		  }
		});

			});

		}

		public static void AddController(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddControllers().AddNewtonsoftJson();
		}

		public static void AddVersion(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddApiVersioning(config =>
			{
				config.DefaultApiVersion = new ApiVersion(1, 0);
				config.AssumeDefaultVersionWhenUnspecified = true;
				config.ReportApiVersions = true;
			});
		}


	}
}
