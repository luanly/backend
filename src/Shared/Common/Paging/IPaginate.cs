﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Paging
{
	public interface IPaginate<T>
	{
		int From { get; }

		int Index { get; }

		int Size { get; }

		int Count { get; }

		int Pages { get; }

		IList<T> Items { get; }

		bool HasPrevious { get; }

		bool HasNext { get; }
	}
}