namespace ASPLearning.Context.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Text : BaseEntity
{
	public string Title { get; set; }
	public string Content { get; set; }
	public int Size { get; set; }
	public ICollection<Trial> Trials { get; set; }
}
