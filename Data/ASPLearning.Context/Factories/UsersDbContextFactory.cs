namespace ASPLearning.Context;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class UsersDbContextFactory
{
	private readonly DbContextOptions<UsersDbContext> _options;

	public UsersDbContextFactory(DbContextOptions<UsersDbContext> options)
	{
		_options = options;
	}

	public UsersDbContext Create()
	{
		return new UsersDbContext(_options);
	}
}

