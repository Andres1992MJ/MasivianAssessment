using FluentValidation;
using Models;
using System;

namespace API.Validation
{
    public class RouletteBetPayloadValidation : AbstractValidator<RouletteBetPayload>
    {
        public RouletteBetPayloadValidation()
        {
            RuleFor(x => x.MoneyBet).GreaterThan(0).LessThanOrEqualTo(10000)
            .WithMessage("El valor de la apuesta debe ser mayor que $0  y menor o igual a $10000");
            RuleFor(x => x.NumberOrColorBet).Must(ValidatorNumberOrColorBet)
            .WithMessage("Se debe apostar un numero entre 0 y 36 o al color Rojo o Negro");
        }
        public bool ValidatorNumberOrColorBet(string numberOrColorBet)
        {
            if (string.IsNullOrWhiteSpace(numberOrColorBet))
            {
                return false;
            }
            else
            {
                if (numberOrColorBet.ToLower() == "rojo" || numberOrColorBet.ToLower() == "negro")
                {
                    return true;
                }
                var result = Int32.TryParse(numberOrColorBet, out int betNumber);
                if (result)
                {
                    return (betNumber >= 0 && betNumber <= 36);
                }
                return false;
            }
        }
    }
}
