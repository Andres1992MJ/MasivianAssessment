using FluentValidation;
using Models;


namespace API.Validation
{
    public class RouletteCreatePayloadValidation : AbstractValidator<RouletteCreatePayload>
    {
        public RouletteCreatePayloadValidation()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0)
            .WithMessage("El ID de ruleta debe ser mayor que 0");
        }
    }
}
