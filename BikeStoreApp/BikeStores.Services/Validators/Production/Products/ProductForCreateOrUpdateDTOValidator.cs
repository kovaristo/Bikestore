using BikeStores.Contracts.Production.Brands;
using BikeStores.Contracts.Production.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Validators.Production.Products
{
    public class ProductForCreateOrUpdateDTOValidator : AbstractValidator<ProductForCreateOrUpdateDTO>
    {
        public ProductForCreateOrUpdateDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(255);
            RuleFor(x => x.ModelYear).GreaterThanOrEqualTo((short)1990).LessThanOrEqualTo((short)DateTime.Now.Year);
        }
    }
}
