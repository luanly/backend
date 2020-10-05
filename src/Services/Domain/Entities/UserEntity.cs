using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class UserEntity : IBaseEntity<Guid>, ICreatedEntity, IUpdatedEntity
	{
		public Guid Id { get; set; }
		public string UserName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public DateTime? CreatedAt { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string UpdatedBy { get; set; }
	}
}
