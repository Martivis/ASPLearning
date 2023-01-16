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
		public DbSet<Text> Texts { get; set; }
		public DbSet<Trial> Trials { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.HasDefaultSchema("appdb");


			modelBuilder.Entity<User>().ToTable("users");

			modelBuilder.Entity<User>()
				.HasIndex(t => t.Name)
				.IsUnique();
			modelBuilder.Entity<User>().Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(15);

			modelBuilder.Entity<Text>().ToTable("texts");
			modelBuilder.Entity<Text>().Property(t => t.Title)
				.IsRequired()
				.HasMaxLength(50);
			modelBuilder.Entity<Text>().Property(t => t.Content)
				.IsRequired();

			modelBuilder.Entity<Trial>().ToTable("trials");
			modelBuilder.Entity<Trial>().Property(t => t.AverageSpeed)
				.IsRequired();
			modelBuilder.Entity<Trial>().Property(t => t.Time)
				.IsRequired();

			modelBuilder.Entity<Trial>()
				.HasOne(t => t.User)
				.WithMany(t => t.Trials);
			modelBuilder.Entity<Trial>()
				.HasOne(t => t.Text)
				.WithMany(t => t.Trials);
		}
	}
}
