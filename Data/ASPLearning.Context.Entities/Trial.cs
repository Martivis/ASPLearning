using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPLearning.Context.Entities;

public class Trial : BaseEntity
{
	public virtual User User { get; set; }
	public virtual Text Text { get; set; }
	public int AverageSpeed { get; set; }
	public TimeOnly Time { get; set; }
}
