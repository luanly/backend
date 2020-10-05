using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Infrastructure.Persistence
{
	public class AppUser : IdentityUser<string>
	{
		public string Name { get; set; }
	}
}