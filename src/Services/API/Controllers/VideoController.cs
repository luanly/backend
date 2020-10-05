using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/Video")]
	[ApiVersion("1.0")]
	public class VideoController : ControllerBase
	{
		[HttpGet]
		[Authorize(Policy = "videoPolicy")]
		public IActionResult Get()
		{
			return this.Ok("Hello");
		}
	}
}
