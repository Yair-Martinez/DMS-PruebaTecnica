using Microsoft.AspNetCore.Mvc;
using TaskManager.Backend.Models.Entities;
using TaskManager.Backend.Repositories.TareaRepository;

namespace TaskManager.Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TareaController : ControllerBase
	{
		private readonly ITareaRepository _repository;

		public TareaController(ITareaRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _repository.GetAllTareasAsync();
			if (response == null) return NotFound();

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var response = await _repository.GetTareaAsync(id);
			if (response == null) return NotFound();

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Post(Tarea tarea)
		{
			var response = await _repository.CreateTareaAsync(tarea);
			if (response == null) return NotFound();

			return CreatedAtAction(nameof(Get), new { id = tarea.Id }, tarea);
		}
	}
}
