using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Features.UserFeatures.Commands;
using Service.Features.UserFeatures.Queries;
using System;
using Common.Paging;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/User")]
	[ApiVersion("1.0")]
	public class UserController : ControllerBase
	{
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

		[HttpPost]
		public async Task<IActionResult> Create(CreateUserCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

		[HttpGet()]
		[Route("{size}/{page}")]
		[Authorize]
		public async Task<IActionResult> GetAllAndPaging( int size, int page)
		{
			return Ok(await Mediator.Send(new GetAllUserQuery { PageSize = size, PageNumber = page}));
		}

		//[HttpGet()]
		//[Authorize]
		//public async Task<IActionResult> GetAll()
		//{
		//	return Ok(await Mediator.Send(new GetAllUserQuery()));
		//}


		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetById(Guid id)
		{
			return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			return Ok(await Mediator.Send(new DeleteUserByIdCommand { Id = id }));
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, UpdateUserCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}
			return Ok(await Mediator.Send(command));
		}
	}
}
