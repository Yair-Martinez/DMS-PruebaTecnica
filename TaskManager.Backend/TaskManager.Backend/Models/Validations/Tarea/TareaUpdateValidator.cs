using FluentValidation;
using FluentValidation.Results;
using TaskManager.Backend.Exceptions;
using TaskManager.Backend.Models.DTOs.Tarea;

namespace TaskManager.Backend.Models.Validations.Tarea
{
	public class TareaUpdateValidator : AbstractValidator<TareaUpdateDto>
	{
		public TareaUpdateValidator()
		{
			RuleFor(t => t.Id).NotNull().NotEmpty().WithMessage("Por favor, ingrese un Id");
			RuleFor(t => t.Titulo).NotNull().NotEmpty().WithMessage("Por favor, ingrese un título");
			RuleFor(t => t.Descripcion).NotNull().NotEmpty().WithMessage("Por favor, ingrese una descripción");
			RuleFor(t => t.Estado).NotNull().WithMessage("Por favor, ingrese un estado");
			RuleFor(t => t.UsuarioId).NotNull().NotEmpty().WithMessage("Por favor, ingrese un UsuarioId");
		}

		protected override void RaiseValidationException(ValidationContext<TareaUpdateDto> context, ValidationResult result)
		{
			var ex = new ValidationException(result.Errors);
			throw new BadRequestException(ex.Message);
		}
	}
}
