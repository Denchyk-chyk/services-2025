using Lab7Api.Models;
using Lab7Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab7Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
	private readonly IBookService _service;

	public BooksController(IBookService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var books = await _service.GetAllAsync();
		return Ok(books);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var book = await _service.GetByIdAsync(id);
		if (book == null)
			return NotFound();
		return Ok(book);
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] InputBookDto dto)
	{
		var id = await _service.InsertOrUpdateAsync(null, dto);
		var created = await _service.GetByIdAsync(id);
		return CreatedAtAction(nameof(GetById), new { id }, created);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, [FromBody] InputBookDto dto)
	{
		await _service.InsertOrUpdateAsync(id, dto);
		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		await _service.DeleteAsync(id);
		return NoContent();
	}
}
