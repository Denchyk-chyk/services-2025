using Lab6.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Lab6.Services;

public class UserService(AppDbContext context) : IUserService
{
	private readonly AppDbContext _context = context;

	public async Task AddAsync(User user)
	{
		await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var user = await _context.Users.FindAsync(id);

		if (user is not null)
		{
			_context.Users.Remove(user);
			await _context.SaveChangesAsync();
		}
	}

	public async Task<List<User>> GetAllAsync()
	{
		return await _context.Users.ToListAsync();
	}

	public async Task<User?> GetByEmailAsync(string email)
	{
		return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
	}

	public async Task<User?> GetByIdAsync(int id)
	{
		return await _context.Users.FindAsync(id);
	}

	public async Task<User?> GetByNameAsync(string name)
	{
		return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
	}

	public async Task UpdateAsync(User user)
	{
		var existingUser = await _context.Users.FindAsync(user.Id);

		if (existingUser is not null)
		{
			existingUser.Name = user.Name;
			existingUser.PasswordHash = user.PasswordHash;
			existingUser.Email = user.Email;
			existingUser.IsAdmin = user.IsAdmin;

			await _context.SaveChangesAsync();
		}
	}

	public async Task<User?> ValidateAsync(string login, string password)
	{
		var user = await GetByNameAsync(login);

		if (user is null)
		{
			user = await GetByEmailAsync(login);
		}

		if (user is not null &&
			SHA512.HashData(Encoding.UTF8.GetBytes(password)).SequenceEqual(user.PasswordHash))
		{
			return user;
		}

		return null;
	}
}
