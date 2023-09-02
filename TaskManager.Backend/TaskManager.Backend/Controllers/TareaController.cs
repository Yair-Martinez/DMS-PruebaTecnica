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

			var tareasReadOnlyDto = _mapper.Map<IEnumerable<TareaReadOnlyDto>>(tareas);
			return Ok(tareasReadOnlyDto);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var tarea = await _repository.GetTareaAsync(id);

			var tareaReadOnlyDto = _mapper.Map<TareaReadOnlyDto>(tarea);
			return Ok(tareaReadOnlyDto);
		}

		[HttpPost]
		public async Task<IActionResult> Post(TareaCreateDto tareaCreateDto)
		{
			var tarea = _mapper.Map<Tarea>(tareaCreateDto);
			await _repository.CreateTareaAsync(tarea);

			return CreatedAtAction(nameof(Get), new { id = tarea.Id }, tarea);
		}
	}
}
