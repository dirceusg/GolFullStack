using FluentValidation;
using GolFullStack.Entity.Entities.Business;

namespace GolFullStack.Domain.Validation.Business
{
    public class AirplaneValidation : AbstractValidator<Airplane>
    {
        public AirplaneValidation()
        {
            RuleFor(c => c.Modelo)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.QuantidadePassageiros)
             .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")             .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} deve ser maior que 0");            RuleFor(c => c.RegistradoEm)
             .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");             
        }
    }
}
