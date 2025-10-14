using DevFreela.Application.Commands.ProjectCommands.InsertProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class InsertProjectValidator : AbstractValidator<InsertProjectCommand>
    {
        public InsertProjectValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                    .WithMessage("O título não pode ser vazio.")
                .MaximumLength(50)
                    .WithMessage("O tamanho máximo é 50 caracteres.");

            RuleFor(p => p.TotalCost)
                .GreaterThanOrEqualTo(1000)
                    .WithMessage("O valor deve ser no mínimo R$1.000,00.");
        }
    }
}
