﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Server.Models
{
	public class ExternalProvider
	{
		public string DisplayName { get; set; }
		public string AuthenticationScheme { get; set; }
	}
}