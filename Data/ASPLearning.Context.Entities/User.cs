namespace ASPLearning.Context.Entities;

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class User : IdentityUser<Guid>
{ 
	public int AverageSpeed { get; set; } = 0;
	public int TextsCount { get; set; } = 0;
	public ICollection<Trial> Trials { get; set; }
}
