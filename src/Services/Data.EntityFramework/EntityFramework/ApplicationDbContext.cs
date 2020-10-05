using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.EntityFramework.EntityFramework
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		#region Fields & Constructor
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		#endregion

		#region Overide Methods
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		#endregion

		public virtual DbSet<UserEntity> UserEntities { get; set; }
	}
}
