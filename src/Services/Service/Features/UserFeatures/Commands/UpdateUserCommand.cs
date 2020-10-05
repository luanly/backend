using Domain.Contracts;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Features.UserFeatures.Commands
{
	public class UpdateUserCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public string UserName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }

		public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
		{

			private readonly IUnitOfWork unitOfWork;

			public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
			{
				this.unitOfWork = unitOfWork;
			}
			public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
			{
				var repo = unitOfWork.GetRepository<UserEntity>();
				var user = repo.SingleOrDefault(user => user.Id == request.Id);

				if (user == null)
				{
					return default;
				}
				else
				{
					repo.Update(user);
					await unitOfWork.CommitAsync();
					return request.Id;
				}
			}
		}
	}
}