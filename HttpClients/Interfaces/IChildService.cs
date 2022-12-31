using Domain;
using Domain.DTOs;
using HttpClients.Impl;

namespace HttpClients.Interfaces;

public interface IChildService
{
	Task<Child> CreateAsync(ChildCreationDto child);
	Task<IEnumerable<Child>> GetAllAsync();
	Task<Child> GetByIdAsync(int id);
}
