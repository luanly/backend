using Domain.Contracts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Features.UserFeatures.Queries
{
	public class GetUserByIdQuery : IRequest<UserEntity>
	{
		public Guid Id { get; set; }
		public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserEntity>
		{
			private readonly IUnitOfWork unitOfWork;
			public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
			{
				this.unitOfWork = unitOfWork;
			}

			public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
			{
				var repo = unitOfWork.GetRepository<UserEntity>();
				var user = repo.SingleOrDefault(u => u.Id == request.Id);

				await unitOfWork.CommitAsync();
				return user;
			}
		}
	}
}
