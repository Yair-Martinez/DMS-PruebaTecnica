using System.ComponentModel.DataAnnotations;

namespace TaskManager.Backend.Models.Entities
{
	public class Tarea
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public string Titulo { get; set; } = string.Empty;
		[Required]
		public string Descripcion { get; set; } = string.Empty;
		[Required]
		public Estados Estado { get; set; }
	}

	public enum Estados
	{
		Pendiente,
		Completada
	}
}
