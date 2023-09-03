using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Backend.Models.DTOs.Tarea;
using TaskManager.Backend.Models.Entities;
using TaskManager.Backend.Models.Validations.Tarea;
using TaskManager.Backend.Repositories.TareaRepository;

namespace TaskManager.Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class TareaController : ControllerBase
	{
		private readonly ITareaRepository _repository;
		private readonly IMapper _mapper;
		private readonly TareaCreateValidator _validator;

		public TareaController(
			ITareaRepository repository,
			IMapper mapper,
			TareaCreateValidator validator)
		{
			_repository = repository;
			_mapper = mapper;
			_validator = validator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var tareas = await _repository.GetAllTareasAsync();

			var tareasReadOnlyDto = _mapper.Map<IEnumerable<TareaReadOnlyDto>>(tareas);
			return Ok(tareasReadOnlyDto);
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetByUser(Guid userId)
		{
			var tareas = await _repository.GetTareasByUserAsync(userId);

			var tareaReadOnlyDto = _mapper.Map<IEnumerable<TareaReadOnlyDto>>(tareas);
			return Ok(tareaReadOnlyDto);
		}

		[HttpPost]
		public async Task<IActionResult> Post(TareaCreateDto tareaCreateDto)
		{
			_validator.ValidateAndThrow(tareaCreateDto);

			var tarea = _mapper.Map<Tarea>(tareaCreateDto);
			await _repository.CreateTareaAsync(tarea);

			return CreatedAtAction(null, new { id = tarea.Id }, tarea);
		}
	}
}
