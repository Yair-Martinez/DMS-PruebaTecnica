using TaskManager.Backend.Models.DTOs.Usuario;
using TaskManager.Backend.Models.Entities;

namespace TaskManager.Backend.Repositories.UsuarioRepository
{
	public interface IUsuarioRepository
	{
		Task Register(Usuario usuario);
		UsuarioReponseDto Login(UsuarioLoginDto usuario);
	}
}
