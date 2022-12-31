using Domain;

namespace App.DaoInterfaces;

public interface IChildDao
{
	Task<Child?> CreateAsync(Child? child);
	Task<IEnumerable<Child?>> GetAllAsync();
	Task<Child?> GetByIdAsync(int id);

}
