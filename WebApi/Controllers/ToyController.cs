using App.LogicImplementations;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ToyController : ControllerBase
{
	private IToyLogic Logic;

	public ToyController(IToyLogic logic)
	{
		Logic = logic;
	}

	[HttpPost]
	public async Task<ActionResult<Toy>> CreateAsync(ToyCreationDto dto)
	{
		try
		{
			Toy created = await Logic.CreateAsync(dto);
			return Created($"/toys/{created.Id}", created);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Toy>>> GetAllAsync()
	{
		try
		{
			IEnumerable<Toy> toys = await Logic.GetAllAsync();
			return Ok(toys);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}
}
