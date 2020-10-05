using Common.Paging;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.EntityFramework.Services
{
	public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected readonly DbContext _dbContext;
		protected readonly DbSet<T> _dbSet;

		public BaseRepository(DbContext context)
		{
			_dbContext = context ?? throw new ArgumentException(nameof(context));
			_dbSet = _dbContext.Set<T>();
		}

		public T SingleOrDefault(Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
			bool enableTracking = true)
		{
			IQueryable<T> query = _dbSet;
			if (!enableTracking) query = query.AsNoTracking();

			if (include != null) query = include(query);

			if (predicate != null) query = query.Where(predicate);

			if (orderBy != null)
				return orderBy(query).FirstOrDefault();
			return query.FirstOrDefault();
		}

		public IPaginate<T> GetList(Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int index = 1,
			int size = 15, bool enableTracking = true)
		{
			IQueryable<T> query = _dbSet;
			if (!enableTracking) query = query.AsNoTracking();

			if (include != null) query = include(query);

			if (predicate != null) query = query.Where(predicate);

			return orderBy != null ? orderBy(query).ToPaginate(index, size) : query.ToPaginate(index, size);
		}


		public IPaginate<TResult> GetList<TResult>(Expression<Func<T, TResult>> selector,
			Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
			int index = 1, int size = 15, bool enableTracking = true) where TResult : class
		{
			IQueryable<T> query = _dbSet;
			if (!enableTracking) query = query.AsNoTracking();

			if (include != null) query = include(query);

			if (predicate != null) query = query.Where(predicate);

			return orderBy != null
				? orderBy(query).Select(selector).ToPaginate(index, size)
				: query.Select(selector).ToPaginate(index, size);
		}
	}
}