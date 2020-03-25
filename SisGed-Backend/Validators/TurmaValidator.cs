using System;
using FluentValidation;
using SisGed_Backend.Models;

namespace SisGed_Backend.Validators
{
    public class TurmaValidator: AbstractValidator<Turma>
    {
        public TurmaValidator()
        {
            RuleFor(t => t.Codigo)
                .NotEmpty().WithMessage("O campo código é obrigatório!")
                .MaximumLength(20).WithMessage("O campo código precisa ter até 20 caracteres!");

            RuleFor(t => t.TipoEnsino)
                .NotEmpty().WithMessage("O campo tipo de ensino precisa ser informado!");

            RuleFor(t => t.Ano)
                .NotEmpty().WithMessage("O campo ano é obrigatório!");

            RuleFor(t => t.Escola)
                .NotEmpty().WithMessage("A escola precisa ser informada!");

        }
    }
}
