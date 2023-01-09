using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPLearning.Context.Entities;

namespace ASPLearning.Context
{
	public class UsersDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }

	}
}
