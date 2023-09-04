using System.ComponentModel.DataAnnotations;
using TaskManager.Backend.Models.Entities;

namespace TaskManager.Backend.Models.DTOs.Tarea
{
	public class TareaUpdateDto
	{
		public Guid Id { get; set; }
		public string Titulo { get; set; } = string.Empty;
		public string Descripcion { get; set; } = string.Empty;
		public Estados Estado { get; set; }
		public Guid UsuarioId { get; set; }
	}
}
