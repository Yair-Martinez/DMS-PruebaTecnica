﻿namespace TaskManager.Backend.Models.DTOs.Usuario
{
	public class UsuarioReponseDto
	{
		public string Token { get; set; } = string.Empty;
		public Guid UsuarioId { get; set; }
	}
}
