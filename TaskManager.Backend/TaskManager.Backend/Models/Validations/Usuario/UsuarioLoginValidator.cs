using FluentValidation;
using FluentValidation.Results;
using TaskManager.Backend.Exceptions;
using TaskManager.Backend.Models.DTOs.Usuario;

namespace TaskManager.Backend.Models.Validations.Usuario
{
	public class UsuarioLoginValidator : AbstractValidator<UsuarioLoginDto>
	{
		public UsuarioLoginValidator()
		{
			RuleFor(u => u.Email).NotNull().NotEmpty().EmailAddress().WithMessage("Por favor, ingrese un email válido");
			RuleFor(u => u.Password).NotNull().NotEmpty().Length(6, 20).WithMessage("La contraseña debe tener entre 6 y 20 caracteres");
		}

		protected override void RaiseValidationException(ValidationContext<UsuarioLoginDto> context, ValidationResult result)
		{
			var ex = new ValidationException(result.Errors);
			throw new BadRequestException(ex.Message);
		}
	}
}
