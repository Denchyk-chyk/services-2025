using Lab7Api.Models;
using Npgsql;
using System.Data;

namespace Lab7Api.Services;

public class BookService(string connectionectionString) : IBookService
{
	private readonly string _connectionString = connectionectionString;

	public async Task<IEnumerable<BookDto>> GetAllAsync()
	{
		var result = new List<BookDto>();

		using var connection = new NpgsqlConnection(_connectionString);
		await connection.OpenAsync();

		using var cmd = new NpgsqlCommand("SELECT * FROM get_all_books()", connection);
		using var reader = await cmd.ExecuteReaderAsync();

		while (await reader.ReadAsync())
		{
			result.Add(ReadBook(reader));
		}

		return result;
	}

	public async Task<BookDto?> GetByIdAsync(int bookId)
	{
		using var connection = new NpgsqlConnection(_connectionString);
		await connection.OpenAsync();

		using var cmd = new NpgsqlCommand("SELECT * FROM get_book_by_id(@id)", connection);
		cmd.Parameters.AddWithValue("id", bookId);

		using var reader = await cmd.ExecuteReaderAsync();
		if (await reader.ReadAsync())
		{
			return ReadBook(reader);
		}

		return null;
	}

	public async Task<int> InsertOrUpdateAsync(int? id, InputBookDto book)
	{
		using var connection = new NpgsqlConnection(_connectionString);
		await connection.OpenAsync();

		using (var cmd = new NpgsqlCommand("SELECT insert_or_update_book(@title, @auth, @genre, @pub, @price, @year, @id)", connection))
		{
			cmd.Parameters.AddWithValue("title", book.Title);
			cmd.Parameters.AddWithValue("auth", book.Author);
			cmd.Parameters.AddWithValue("genre", book.Genre);
			cmd.Parameters.AddWithValue("pub", book.Publisher);
			cmd.Parameters.AddWithValue("price", book.Price);
			cmd.Parameters.AddWithValue("year", book.Year);
			cmd.Parameters.AddWithValue("id", (object?)id ?? DBNull.Value);

			return (int)await cmd.ExecuteScalarAsync();
		}
	}

	public async Task DeleteAsync(int bookId)
	{
		using var connection = new NpgsqlConnection(_connectionString);
		await connection.OpenAsync();

		using var cmd = new NpgsqlCommand("SELECT delete_book(@id)", connection);
		cmd.Parameters.AddWithValue("id", bookId);

		await cmd.ExecuteNonQueryAsync();
	}

	private static BookDto ReadBook(IDataRecord r) => new()
	{
		Id = r.GetInt32(r.GetOrdinal("id")),
		Title = r.GetString(r.GetOrdinal("title")),
		Author = r.GetString(r.GetOrdinal("author")),
		Genre = r.GetString(r.GetOrdinal("genre")),
		Publisher = r.GetString(r.GetOrdinal("publisher")),
		Price = r.GetDecimal(r.GetOrdinal("price")),
		Year = r.GetInt32(r.GetOrdinal("year"))
	};
}
