using TaskManager.Backend.Models.Entities;

namespace TaskManager.Backend.Models.DTOs.Tarea
{
	public class TareaReadOnlyDto
	{
		string Titulo { get; set; } = string.Empty;
		string Descripcion { get; set; } = string.Empty;
		Estados Estado { get; set; }
	}
}
