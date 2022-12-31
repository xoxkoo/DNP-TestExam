using App.Logic;
using App.LogicImplementations;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChildController : ControllerBase
{
	private IChildLogic Logic;

	public ChildController(IChildLogic logic)
	{
		Logic = logic;
	}

	[HttpPost]
	public async Task<ActionResult<Child>> CreateAsync(ChildCreationDto dto)
	{
		try
		{
			Child? created = await Logic.CreateAsync(dto);
			return Created($"/children/{created.Id}", created);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Child>>> GetAllAsync()
	{
		try
		{
			IEnumerable<Child?> list = await Logic.GetAll();
			return Ok(list);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet, Route("get-by-id")]
	public async Task<ActionResult<IEnumerable<Child>>> GetByIdAsync([FromQuery] int id)
	{
		try
		{
			Child? child = await Logic.GetById(id);
			return Ok(child);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}
}
