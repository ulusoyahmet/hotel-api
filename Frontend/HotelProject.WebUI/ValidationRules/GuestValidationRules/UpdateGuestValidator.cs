using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator: AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name field cannot be empty")
                .MinimumLength(3)
                .WithMessage("Name cannot be shorter than 3 characters")
                .MaximumLength(20)
                .WithMessage("Name cannot be longer than 20 characters");

            RuleFor(x => x.Surname)
                    .NotEmpty()
                    .WithMessage("Surname field cannot be empty")
                    .MinimumLength(2)
                    .WithMessage("Surname cannot be shorter than 2 characters")
                    .MaximumLength(30)
                    .WithMessage("Surname cannot be longer than 30 characters");

            RuleFor(x => x.City)
                    .NotEmpty()
                    .WithMessage("City field cannot be empty")
                    .MinimumLength(3)
                    .WithMessage("City cannot be shorter than 2 characters")
                    .MaximumLength(25)
                    .WithMessage("City cannot be longer than 25 characters");
        }
    }
}
