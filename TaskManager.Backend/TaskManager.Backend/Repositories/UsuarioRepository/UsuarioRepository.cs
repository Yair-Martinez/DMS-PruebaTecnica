using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Backend.Data;
using TaskManager.Backend.Exceptions;
using TaskManager.Backend.Models.DTOs.Usuario;
using TaskManager.Backend.Models.Entities;

namespace TaskManager.Backend.Repositories.UsuarioRepository
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly DataContext _dataContext;
		private readonly IConfiguration _configuration;

		public UsuarioRepository(DataContext dataContext, IConfiguration configuration)
		{
			_dataContext = dataContext;
			_configuration = configuration;
		}
		public async Task Register(Usuario usuario)
		{
			var userByEmail = (from u in _dataContext.Usuarios
												 where u.Email == usuario.Email
												 select u).FirstOrDefault();

			if (userByEmail != null)
				throw new UnauthorizedException($"Usuario con Email {usuario.Email} ya se encuentra registrado.");

			string passHash = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
			usuario.Password = passHash;

			_dataContext.Usuarios.Add(usuario);
			await _dataContext.SaveChangesAsync();
		}

		public UsuarioReponseDto Login(UsuarioLoginDto usuarioDto)
		{
			var userByEmail = (from u in _dataContext.Usuarios
												 where u.Email == usuarioDto.Email
												 select u).FirstOrDefault();

			if (userByEmail == null)
				throw new UnauthorizedException($"Usuario con Email {usuarioDto.Email} no se encuentra registrado.");

			var checkPass = BCrypt.Net.BCrypt.Verify(usuarioDto.Password, userByEmail.Password);
			if (!checkPass) throw new UnauthorizedException($"Las credenciales son inválidas.");

			string token = CreateToken(usuarioDto.Email);

			return new UsuarioReponseDto
			{
				Token = token,
				Id = userByEmail.Id,
			};
		}

		private string CreateToken(string email)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email, email)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
				_configuration.GetSection("AppSettings:JwtSecretKey").Value!));

			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var jwtSecurityToken = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddMinutes(60),
				signingCredentials: credentials
				);

			var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

			return token;
		}
	}
}
