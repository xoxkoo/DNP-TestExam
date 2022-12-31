using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Toy
{
	[Key]
	public int Id { get; set; }
	public int ChildId { get; set; }
	[Required, MaxLength(20)]
	public string Name { get; set; }
	public string Color { get; set; }
	public string Condition { get; set; }
	public bool IsFavourite { get; set; }

	public Toy()
	{
	}
}
