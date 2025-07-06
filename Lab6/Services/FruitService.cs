using Lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Services;

public class FruitService(AppDbContext context) : IFruitService
{
	private readonly AppDbContext _context = context;

	public async Task AddAsync(Fruit fruit)
	{
		await _context.Fruits.AddAsync(fruit);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var fruit = await _context.Fruits.FindAsync(id);

		if (fruit is not null)
		{
			_context.Fruits.Remove(fruit);
			await _context.SaveChangesAsync();
		}
	}

	public async Task<List<Fruit>> GetAllAsync()
	{
		return await _context.Fruits.ToListAsync();
	}

	public async Task<Fruit?> GetByIdAsync(int id)
	{
		return await _context.Fruits.FindAsync(id);
	}

	public async Task UpdateAsync(Fruit fruit)
	{
		var existingFruit = await _context.Fruits.FindAsync(fruit.Id);

		if (existingFruit is not null)
		{
			existingFruit.Name = fruit.Name;
			existingFruit.Description = fruit.Description;
			existingFruit.Price = fruit.Price;
			existingFruit.ImageUrl = fruit.ImageUrl;

			await _context.SaveChangesAsync();
		}
	}
}
