using Lab6.Models;

namespace Lab6.Services;

public interface IFruitService
{
	Task<List<Fruit>> GetAllAsync();

	Task<Fruit?> GetByIdAsync(int id);

	Task AddAsync(Fruit fruit);

	Task UpdateAsync(Fruit fruit);

	Task DeleteAsync(int id);
}
