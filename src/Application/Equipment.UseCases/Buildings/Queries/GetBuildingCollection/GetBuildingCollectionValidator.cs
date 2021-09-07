using FluentValidation;

namespace Equipment.UseCases.Buildings.Queries.GetBuildingCollection
{
    public class GetBuildingCollectionValidator : AbstractValidator<GetBuildingCollectionQuery>
    {
        public GetBuildingCollectionValidator()
        {
            RuleFor(x => x.Length).Must(x => x == null || x > 0);
            RuleFor(x => x.Offset).Must(x => x == null || x >= 0);
        }
    }
}
