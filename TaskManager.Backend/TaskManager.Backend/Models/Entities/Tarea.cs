using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
		[Required]
		public Guid UsuarioId { get; set; }
		[JsonIgnore]
		public Usuario Usuario { get; set; } = null!;
	}

	public enum Estados
	{
		Pendiente,
		Completada
	}
}
