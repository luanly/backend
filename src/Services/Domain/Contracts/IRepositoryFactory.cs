using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
	public interface IRepositoryFactory
	{
		IRepository<T> GetRepository<T>() where T : class;
	}
}