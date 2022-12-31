using Domain;
using Domain.DTOs;

namespace App.LogicImplementations;

public interface IChildLogic
{
	Task<Child?> CreateAsync(ChildCreationDto child);
	Task<IEnumerable<Child?>> GetAll();
	Task<Child?> GetById(int id);
}
