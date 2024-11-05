using FluentValidation;

namespace Serializer.Validators.PersonDtoValidators;

public class PersonPostDtoValidator : AbstractValidator<PersonPostDto>
{
    public PersonPostDtoValidator()
    {
        RuleFor(x => x.Firstname).NotEmpty().MaximumLength(5000).MinimumLength(2).WithMessage("Musa");
        RuleFor(x => x.Lastname).NotEmpty().MaximumLength(256).MinimumLength(2);
        RuleFor(x => x.Age).GreaterThan(0).LessThan(100);

    }
}
