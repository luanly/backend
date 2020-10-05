using Identity.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Server.Models
{
	public class RegisterResponseViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public RegisterResponseViewModel(AppUser user)
		{
			Id = user.Id.ToString();
			Name = user.Name;
			Email = user.Email;
		}
	}
}