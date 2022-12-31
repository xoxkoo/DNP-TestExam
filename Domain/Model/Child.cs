using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain;

public class Child
{

	[Key]
	public int Id { get; set; }
	[Required, MaxLength(50)]
	public string Name { get; set; }
	[Required, Range(3, 6)]
	public int Age { get; set; }
	[Required]
	public string Gender { get; set; }

	public ICollection<Toy> Toys { get; set; }


}
