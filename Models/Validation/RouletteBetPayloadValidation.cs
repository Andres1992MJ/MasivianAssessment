using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Validation
{
    public class RouletteBetPayloadValidation: AbstractValidator<RouletteBetPayload>
    {
        public RouletteBetPayloadValidation()
        {
            RuleFor(x => x.MoneyBet).GreaterThan(0).LessThanOrEqualTo(10000)
                .WithMessage("El valor de la apuesta debe ser mayor que $0  y menor o igual a $10000");           
        }
    }
}
