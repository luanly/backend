using Domain.Contracts;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Features.UserFeatures.Commands
{
	public class CreateUserCommand : IRequest<Guid>
	{
		public string UserName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
		{
			//private readonly IRepositoryAsync<UserEntity> userRpository;
			private readonly IUnitOfWork unitOfWork;
			public CreateUserCommandHandler(IUnitOfWork unitOfWork)
			{
				this.unitOfWork = unitOfWork;
			}
			public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
			{
				var user = new UserEntity();
				user.UserName = request.UserName;
				user.Address = request.Address;
				user.Phone = request.Phone;

				await unitOfWork.GetRepository<UserEntity>().InsertAsync(user);


				await unitOfWork.CommitAsync();

				return user.Id;
			}
		}
	}
}
