// IAR jue 08AGO2024

using FluentValidation;

namespace projBaseDemo.Application.Features.Articulo.Queries.GetArticulosWithPagination
{
    public class GetArticulosWithPaginationValidator : AbstractValidator<GetArticulosWithPaginationQuery>
    {
        public GetArticulosWithPaginationValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
