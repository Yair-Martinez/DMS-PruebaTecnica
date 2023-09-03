using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Backend.Models.DTOs.Usuario;
using TaskManager.Backend.Models.Entities;
using TaskManager.Backend.Repositories.UsuarioRepository;

namespace TaskManager.Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioRepository _repository;
		private readonly IMapper _mapper;

		public UsuarioController(IUsuarioRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(UsuarioRegisterDto usuarioDto)
		{
			var usuario = _mapper.Map<Usuario>(usuarioDto);
			await _repository.Register(usuario);

			return CreatedAtAction(null, new { id = usuario.Id }, null);
		}

		[HttpPost("login")]
		public IActionResult Login(UsuarioLoginDto usuarioDto)
		{
			var usuarioResponse = _repository.Login(usuarioDto);

			return Ok(usuarioResponse);
		}
	}
}
