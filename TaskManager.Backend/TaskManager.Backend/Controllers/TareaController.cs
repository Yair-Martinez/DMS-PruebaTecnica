using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Backend.Models.DTOs.Tarea;
using TaskManager.Backend.Models.Entities;
using TaskManager.Backend.Repositories.TareaRepository;

namespace TaskManager.Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TareaController : ControllerBase
	{
		private readonly ITareaRepository _repository;
		private readonly IMapper _mapper;

		public TareaController(ITareaRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var tareas = await _repository.GetAllTareasAsync();
			if (tareas == null) return NotFound();

			var tareasReadOnlyDto = _mapper.Map<IEnumerable<TareaReadOnlyDto>>(tareas);
			return Ok(tareasReadOnlyDto);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var tarea = await _repository.GetTareaAsync(id);
			if (tarea == null) return NotFound();

			var tareaReadOnlyDto = _mapper.Map<TareaReadOnlyDto>(tarea);
			return Ok(tareaReadOnlyDto);
		}

		[HttpPost]
		public async Task<IActionResult> Post(TareaCreateDto tareaCreateDto)
		{
			var tarea = _mapper.Map<Tarea>(tareaCreateDto);

			var response = await _repository.CreateTareaAsync(tarea);
			if (response == null) return BadRequest();

			return CreatedAtAction(nameof(Get), new { id = tarea.Id }, tarea);
		}
	}
}
