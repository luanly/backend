using Common.Paging;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Service.Features.UserFeatures.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Features.UserFeatures.Queries
{
	public class GetAllUserQuery : IRequest<IPaginate<UserEntity>>
	{
		public int PageSize { get; set; }
		public int PageNumber { get; set; }
		public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IPaginate<UserEntity>>
		{
			private readonly IUnitOfWork unitOfWork;
			public GetAllUserQueryHandler(IUnitOfWork unitOfWork)
			{
				this.unitOfWork = unitOfWork;
			}
			public async Task<IPaginate<UserEntity>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
			{
				var repo = unitOfWork.GetRepository<UserEntity>();
				//var userList = await repo.TableNoTracking.Select(n => new UserModel()
				//{
				//	Address = n.Address,
				//	Phone = n.Phone,
				//	UserName = n.UserName,
				//	UserId = n.Id
				//}).ToListAsync();

				var userList = await repo.GetListAsync(size: request.PageSize, index: request.PageNumber);

				if (userList == null)
				{
					return null;
				}

				return userList;
			}
		}
	}
}
