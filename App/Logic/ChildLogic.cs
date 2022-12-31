using App.DaoInterfaces;
using App.LogicImplementations;
using Domain;
using Domain.DTOs;

namespace App.Logic;

public class ChildLogic : IChildLogic
{
	private IChildDao Dao;
	public ChildLogic(IChildDao dao)
	{
		Dao = dao;
	}

	public async Task<Child?> CreateAsync(ChildCreationDto dto)
	{
		Child? child = new Child()
		{
			Name = dto.Name,
			Gender = dto.Gender,
			Age = dto.Age
		};

		return await Dao.CreateAsync(child);
	}

	public async Task<IEnumerable<Child?>> GetAll()
	{
		return await Dao.GetAllAsync();
	}

	public async Task<Child?> GetById(int id)
	{
		return await Dao.GetByIdAsync(id);

	}
}
