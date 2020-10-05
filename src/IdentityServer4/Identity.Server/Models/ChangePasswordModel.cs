using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Server.Models
{
	public class ChangePasswordModel
	{
		public string Id { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string PasswordAgain { get; set; }
	}
}