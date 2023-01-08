using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPLearning.Context.Settings
{
	public class UsersDbSettings
	{
		public DbType DbType { get; set; }
		public string ConnectionString { get; set; }
	}
}
