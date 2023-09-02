using AutoMapper;
using TaskManager.Backend.Models.DTOs.Tarea;
using TaskManager.Backend.Models.Entities;

namespace TaskManager.Backend.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<TareaCreateDto, Tarea>().ReverseMap();
			CreateMap<TareaReadOnlyDto, Tarea>().ReverseMap();
		}
	}
}
