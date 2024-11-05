using FluentValidation;

namespace Serializer.Validators.PersonDtoValidators;

public class PersonPutDtoValidator : AbstractValidator<PersonPutDto>
{
    public PersonPutDtoValidator()
    {

        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Firstname).NotEmpty().MaximumLength(5000).MinimumLength(2).WithMessage("Duzgun yaz");
        RuleFor(x => x.Lastname).NotEmpty().MaximumLength(256).MinimumLength(2);
        RuleFor(x => x.Age).GreaterThan(0).LessThan(100);

    }
}
