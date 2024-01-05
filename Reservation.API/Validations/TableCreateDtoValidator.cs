using FluentValidation;
using Reservation.Core.DTO_s;

namespace Reservation.API.Validations
{
    public class TableCreateDtoValidator:AbstractValidator<TableCreateDto>
    {
        public TableCreateDtoValidator()
        {
            RuleFor(x => x.Capacity).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Number).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
