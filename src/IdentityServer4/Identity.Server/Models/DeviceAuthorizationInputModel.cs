using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Server.Models
{
	public class DeviceAuthorizationInputModel : ConsentInputModel
	{
		public string UserCode { get; set; }
	}
}