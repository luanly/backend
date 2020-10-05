using Data.EntityFramework.EntityFramework;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Services
{
	public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>
	   where TContext : DbContext, IDisposable
	{
		public TContext Context { get; }

		#region Constructor
		public UnitOfWork(TContext context)
		{
			Context = context ?? throw new ArgumentNullException(nameof(DbContext));
		}
		#endregion


		public int Commit()
		{
			return Context.SaveChanges();
		}

		public async Task<int> CommitAsync()
		{
			return await Context.SaveChangesAsync();
		}

		public void Dispose()
		{
			Context?.Dispose();
		}

		public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
		{
			return (IRepository<TEntity>)GetOrAddRepository(typeof(TEntity), new Repository<TEntity>(Context));
		}

		internal object GetOrAddRepository(Type type, object repo)
		{
			_repositories ??= new Dictionary<(Type type, string Name), object>();

			if (_repositories.TryGetValue((type, repo.GetType().FullName), out var repository)) return repository;
			_repositories.Add((type, repo.GetType().FullName), repo);
			return repo;
		}

		#region Private Field
		private Dictionary<(Type type, string name), object> _repositories;
		#endregion
	}
}