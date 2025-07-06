using System.Text.Json;

namespace Lab7Console;

internal class Service
{
	public readonly HttpClient _client = new();

	private async Task<string> ReadAsync(int id = -1)
	{
		var response = await _client.GetAsync(Address(id));
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}

	public async Task<BookDtoExtensions> GetAsync(int id)
	{
		var json = await ReadAsync(id);
		return JsonSerializer.Deserialize<BookDtoExtensions>(json);
	}

	public async Task<BookDtoExtensions[]> GetAllAsync()
	{
		var json = await ReadAsync();
		return JsonSerializer.Deserialize<BookDtoExtensions[]>(json);
	}

	public async Task<BookDtoExtensions> CreateAsync(BookDtoExtensions dto)
	{
		var response = await _client.PostAsync(Address(), dto.ToJsonContent());
		response.EnsureSuccessStatusCode();
		var result = await response.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<BookDtoExtensions>(result);
	}

	public async Task<bool> UpdateAsync(BookDtoExtensions dto)
	{
		var response = await _client.PutAsync(Address(dto.LegitId), dto.ToJsonContent());
		return response.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var response = await _client.DeleteAsync(Address(id));
		return response.IsSuccessStatusCode;
	}

	private static string Address(int id = -1) => "http://localhost:5000/api/books" + (id != -1 ? $"/{id}" : string.Empty);
}
