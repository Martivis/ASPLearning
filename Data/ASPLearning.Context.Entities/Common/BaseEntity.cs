namespace ASPLearning.Context.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Index("Uid", IsUnique = true)]
public class BaseEntity
{
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	[Required]
	public Guid Uid { get; set; } = Guid.NewGuid();
}

