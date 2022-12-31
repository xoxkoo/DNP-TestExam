namespace Domain.DTOs;

public class ChildCreationDto
{
	public string Name { get; set; }
	public int Age { get; set; }
	public string Gender { get; set; }

	public ChildCreationDto(string name, int age, string gender)
	{
		Name = name;
		Age = age;
		Gender = gender;
	}
}
