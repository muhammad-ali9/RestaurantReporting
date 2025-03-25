using Application.DTOs;
using FluentValidation;

namespace Application.Features.Commands.CreateRestaurantCommand
{
    public class CreateRestauratnCommandValidator : AbstractValidator<CreateRestaurantDto>
    {
        public CreateRestauratnCommandValidator()
        {
            RuleFor(x => x.CityName)
                .NotEmpty().WithMessage("City Name is required")
                .NotNull().WithMessage("City Name is required");

            RuleFor(x => x.SerialNumber)
    .GreaterThan(0).WithMessage("Serial Number must be greater than 0.");

            RuleFor(x => x.RestaurantName)
                .NotEmpty().WithMessage("Restaurant Name is required")
                .NotNull().WithMessage("Restaurant Name is required");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required")
                .NotNull().WithMessage("Address is required");
            
        }
    }
}
