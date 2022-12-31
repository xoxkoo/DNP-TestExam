using System.Text;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.Interfaces;

namespace HttpClients.Impl;

public class ToyHttpClient : IToyService
{

	private readonly HttpClient client;

	public ToyHttpClient(HttpClient client)
	{
		this.client = client;
	}

	public async Task<Toy> CreateAsync(ToyCreationDto dto)
	{
		string subFormAsJson = JsonSerializer.Serialize(dto);
		StringContent content = new(subFormAsJson, Encoding.UTF8, "application/json");

		HttpResponseMessage response = await client.PostAsync("https://localhost:7047/toy/", content);
		string result = await response.Content.ReadAsStringAsync();

		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(result);
		}

		Toy toy = JsonSerializer.Deserialize<Toy>(result, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;

		return toy;
	}

	public async Task<IEnumerable<Toy>> GetAllAsync()
	{
		HttpResponseMessage response = await client.GetAsync("https://localhost:7047/toy/");

		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(content);
		}

		ICollection<Toy> toy = JsonSerializer.Deserialize<ICollection<Toy>>(content, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;

		return toy;
	}
}
