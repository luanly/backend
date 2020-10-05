using Domain.Contracts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Features.UserFeatures.Commands
{
	public class DeleteUserByIdCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Guid>
		{
			private readonly IUnitOfWork unitOfWork;

			public DeleteUserByIdCommandHandler(IUnitOfWork unitOfWork)
			{
				this.unitOfWork = unitOfWork;
			}
			public async Task<Guid> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
			{
				var repo = unitOfWork.GetRepository<UserEntity>();

				repo.Delete(request.Id);

				await unitOfWork.CommitAsync();
				return request.Id;
			}
		}
	}
}
