﻿using System.ComponentModel.DataAnnotations;

namespace TaskManager.Backend.Models.DTOs.Usuario
{
	public class UsuarioRegisterDto
	{
		public string Nombre { get; set; } = string.Empty;
		public string Apellido { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
