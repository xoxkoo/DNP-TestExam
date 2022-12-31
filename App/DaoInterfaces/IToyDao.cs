using Domain;

namespace App.DaoInterfaces;

public interface IToyDao
{
	Task<Toy> CreateAsync(Toy toy);
	Task<IEnumerable<Toy>> GetAllAsync();
}
