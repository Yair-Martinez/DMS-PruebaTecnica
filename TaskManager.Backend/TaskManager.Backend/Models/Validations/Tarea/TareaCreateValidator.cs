using FluentValidation;
using FluentValidation.Results;
using TaskManager.Backend.Exceptions;
using TaskManager.Backend.Models.DTOs.Tarea;

namespace TaskManager.Backend.Models.Validations.Tarea
{
	public class TareaCreateValidator : AbstractValidator<TareaCreateDto>
	{
		public TareaCreateValidator()
		{
			RuleFor(t => t.Titulo).NotNull().NotEmpty().WithMessage("Por favor, ingrese un título");
			RuleFor(t => t.Descripcion).NotNull().NotEmpty().WithMessage("Por favor, ingrese una decripción");
			RuleFor(t => t.UsuarioId).NotNull().NotEmpty().WithMessage("Por favor, ingrese un Id");
		}

		protected override void RaiseValidationException(ValidationContext<TareaCreateDto> context, ValidationResult result)
		{
			var ex = new ValidationException(result.Errors);
			throw new BadRequestException(ex.Message);
		}
	}
}
