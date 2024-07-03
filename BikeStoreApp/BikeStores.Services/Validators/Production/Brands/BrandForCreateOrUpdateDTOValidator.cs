using BikeStores.Contracts.Production.Brands;
using FluentValidation;

namespace BikeStores.Services.Validators.Production.Brands
{
    public class BrandForCreateOrUpdateDTOValidator : AbstractValidator<BrandForCreateOrUpdateDTO>
    {
        public BrandForCreateOrUpdateDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(255);
        }
    }
}
