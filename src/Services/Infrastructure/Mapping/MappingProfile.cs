using AutoMapper;
using Domain.Entities;
using Service.Features.UserFeatures.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<UserModel, UserEntity>()
				.ForMember(dest => dest.Id,
						opt => opt.MapFrom(src => src.UserId))
				.ReverseMap();
		}
	}
}
