using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	public interface IBaseEntity<T>
	{
		public T Id { get; set; }
	}
}
