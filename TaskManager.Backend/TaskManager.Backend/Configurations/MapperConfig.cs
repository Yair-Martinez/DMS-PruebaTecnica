using AutoMapper;
using TaskManager.Backend.Models.DTOs.Tarea;
using TaskManager.Backend.Models.DTOs.Usuario;
using TaskManager.Backend.Models.Entities;

namespace TaskManager.Backend.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<TareaCreateDto, Tarea>().ReverseMap();
			CreateMap<TareaReadOnlyDto, Tarea>().ReverseMap();
			CreateMap<TareaUpdateDto, Tarea>().ReverseMap();

			CreateMap<UsuarioRegisterDto, Usuario>().ReverseMap();
			CreateMap<UsuarioLoginDto, Usuario>().ReverseMap();
		}
	}
}
