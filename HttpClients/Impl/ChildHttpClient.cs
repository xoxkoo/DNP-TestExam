using System.Text;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.Interfaces;

namespace HttpClients.Impl;

public class ChildHttpClient : IChildService
{
	private readonly HttpClient client;

	public ChildHttpClient(HttpClient client)
	{
		this.client = client;
	}

	public async Task<Child> CreateAsync(ChildCreationDto dto)
	{
		string subFormAsJson = JsonSerializer.Serialize(dto);
		StringContent content = new(subFormAsJson, Encoding.UTF8, "application/json");

		HttpResponseMessage response = await client.PostAsync("https://localhost:7047/child/", content);
		string result = await response.Content.ReadAsStringAsync();

		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(result);
		}

		Child child = JsonSerializer.Deserialize<Child>(result, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;

		return child;
	}

	public async Task<IEnumerable<Child>> GetAllAsync()
	{
		HttpResponseMessage response = await client.GetAsync("https://localhost:7047/child/");

		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(content);
		}

		ICollection<Child> children = JsonSerializer.Deserialize<ICollection<Child>>(content, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;

		return children;
	}

	public async Task<Child> GetByIdAsync(int id)
	{
		HttpResponseMessage response = await client.GetAsync("https://localhost:7047/child?id=" + id);

		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(content);
		}

		Child child = JsonSerializer.Deserialize<Child>(content, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;

		return child;
	}
}
