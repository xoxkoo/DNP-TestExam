using Domain;
using Domain.DTOs;

namespace App.LogicImplementations;

public interface IToyLogic
{
	Task<Toy> CreateAsync(ToyCreationDto dto);
	Task<IEnumerable<Toy>> GetAllAsync();
}
