﻿using System.ComponentModel.DataAnnotations;

namespace TaskManager.Backend.Models.DTOs.Usuario
{
	public class UsuarioLoginDto
	{
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
