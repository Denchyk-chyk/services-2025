using Lab7Api.Models;

namespace Lab7Api.Services;

public interface IBookService
{
	Task<IEnumerable<BookDto>> GetAllAsync();
	Task<BookDto?> GetByIdAsync(int bookId);
	Task<int> InsertOrUpdateAsync(int? id, InputBookDto book);
	Task DeleteAsync(int bookId);
}
