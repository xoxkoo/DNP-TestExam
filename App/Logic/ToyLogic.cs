using App.DaoInterfaces;
using App.LogicImplementations;
using Domain;
using Domain.DTOs;

namespace App.Logic;

public class ToyLogic : IToyLogic
{

	private IToyDao toyDao;
	private IChildDao childDao;

	public ToyLogic(IToyDao toyDao, IChildDao childDao)
	{
		this.childDao = childDao;
		this.toyDao = toyDao;
	}

	public async Task<Toy> CreateAsync(ToyCreationDto dto)
	{

		Validate(dto);

		Toy toy = new Toy
		{
			Color = dto.Color,
			Condition = dto.Condition,
			Name = dto.Name,
			ChildId = dto.ChildId
		};

		return await toyDao.CreateAsync(toy);
	}

	public async Task<IEnumerable<Toy>> GetAllAsync()
	{
		return await toyDao.GetAllAsync();
	}

	private async void Validate(ToyCreationDto dto)
	{
		Child? child = await childDao.GetByIdAsync(dto.ChildId);

		if (child == null)
		{
			throw new Exception($"Child with id {dto.ChildId} was not found.");
		}
	}
}
