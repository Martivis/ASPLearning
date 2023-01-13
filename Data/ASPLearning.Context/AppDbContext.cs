using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPLearning.Context.Entities;

namespace ASPLearning.Context
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().ToTable("users");
			modelBuilder.HasDefaultSchema("appdb");
		}
	}
}
