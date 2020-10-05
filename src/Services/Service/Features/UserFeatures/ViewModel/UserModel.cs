using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Features.UserFeatures.ViewModel
{
	public class UserModel
	{
		public Guid UserId { get; set; }
		public string UserName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
	}
}
