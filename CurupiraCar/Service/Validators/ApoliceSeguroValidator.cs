using Domain.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validators
{
    public class ApoliceSeguroValidator: AbstractValidator<ApoliceSeguro>
    {
        public ApoliceSeguroValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Objeto não encontrado");
                });
            RuleFor(c => c.IdentificacaoSegurado)
                .NotEmpty().WithMessage("É necessário informar o identificador")
                .NotNull().WithMessage("É necessário informar o identificador");

            RuleFor(c=> c.NumeroApolice)
                .NotEmpty().WithMessage("É necessário informar o número da apólice")
                .NotNull().WithMessage("É necessário informar o número da apólice");

            RuleFor(c=> c.PlacaVeiculo)
                .NotEmpty().WithMessage("É necessário informar a placa do veículo")
                .NotNull().WithMessage("É necessário informar a placa do veículo");

            RuleFor(c=> c.ValorPremio)
                .NotEmpty().WithMessage("É necessário informar o valor do prêmio")
                .NotNull().WithMessage("É necessário informar o valor do prêmio");


        }
    }
}
