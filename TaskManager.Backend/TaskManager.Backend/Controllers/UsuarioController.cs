using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Backend.Models.DTOs.Usuario;
using TaskManager.Backend.Models.Entities;
using TaskManager.Backend.Models.Validations.Usuario;
using TaskManager.Backend.Repositories.UsuarioRepository;

namespace TaskManager.Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioRepository _repository;
		private readonly IMapper _mapper;
		private readonly UsuarioLoginValidator _validatorLogin;
		private readonly UsuarioRegisterValidator _validatorRegister;

		public UsuarioController(
			IUsuarioRepository repository,
			IMapper mapper,
			UsuarioLoginValidator validatorLogin,
			UsuarioRegisterValidator validatorRegister)
		{
			_repository = repository;
			_mapper = mapper;
			_validatorLogin = validatorLogin;
			_validatorRegister = validatorRegister;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(UsuarioRegisterDto usuarioDto)
		{
			_validatorRegister.ValidateAndThrow(usuarioDto);

			var usuario = _mapper.Map<Usuario>(usuarioDto);
			await _repository.Register(usuario);

			return CreatedAtAction(null, new { id = usuario.Id }, null);
		}

		[HttpPost("login")]
		public IActionResult Login(UsuarioLoginDto usuarioDto)
		{
			_validatorLogin.ValidateAndThrow(usuarioDto);

			var usuarioResponse = _repository.Login(usuarioDto);

			return Ok(usuarioResponse);
		}
	}
}
