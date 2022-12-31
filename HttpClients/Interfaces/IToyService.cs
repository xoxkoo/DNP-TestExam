using Domain;
using Domain.DTOs;

namespace HttpClients.Interfaces;

public interface IToyService
{
	Task<Toy> CreateAsync(ToyCreationDto dto);
	Task<IEnumerable<Toy>> GetAllAsync();
}
