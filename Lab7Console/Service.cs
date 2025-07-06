using Lab7Api.Models;
using System.Text.Json;

namespace Lab7Console;

internal class Service
{
	public readonly HttpClient _client = new();

	private readonly JsonSerializerOptions _options = new()
	{
		PropertyNameCaseInsensitive = true
	};

	private async Task<string> ReadAsync(int id = -1)
	{
		var response = await _client.GetAsync(Address(id));
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}

	public async Task<BookDto> GetAsync(int id)
	{
		var json = await ReadAsync(id);
		return JsonSerializer.Deserialize<BookDto>(json, _options);
	}

	public async Task<BookDto[]> GetAllAsync()
	{
		var json = await ReadAsync();
		return JsonSerializer.Deserialize<BookDto[]>(json, _options);
	}

	public async Task<BookDto> CreateAsync(InputBookDto dto)
	{
		var response = await _client.PostAsync(Address(), dto.ToJsonContent());
		response.EnsureSuccessStatusCode();
		var json = await response.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<BookDto>(json, _options);
	}

	public async Task<bool> UpdateAsync(int id, InputBookDto dto)
	{
		var response = await _client.PutAsync(Address(id), dto.ToJsonContent());
		return response.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var response = await _client.DeleteAsync(Address(id));
		return response.IsSuccessStatusCode;
	}

	private static string Address(int id = -1) => "http://localhost:5000/api/books" + (id != -1 ? $"/{id}" : string.Empty);
}
