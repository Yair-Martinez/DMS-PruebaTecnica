﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManager.Backend.Models.Entities
{
	[Index(nameof(Email), IsUnique = true)]
	public class Usuario
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public string Nombre { get; set; } = string.Empty;
		[Required]
		public string Apellido { get; set; } = string.Empty;
		[Required]
		public string Email { get; set; } = string.Empty;
		[Required]
		public string Password { get; set; } = string.Empty;
		[JsonIgnore]
		public ICollection<Tarea> Tareas { get; set; }
	}
}
