using Data.EntityFramework.EntityFramework;
using Data.EntityFramework.Services;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Domain.Contracts;
using Service.Features.UserFeatures.Commands;

namespace Infrastructure.Extension
{
	public static class DependencyInjection
	{
		public static void AddMediatorCQRS(this IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
		}

		public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services)
			where TContext : ApplicationDbContext
		{
			services.AddScoped<IRepositoryFactory, UnitOfWork<TContext>>();
			services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
			services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();
			return services;
		}
	}
}


