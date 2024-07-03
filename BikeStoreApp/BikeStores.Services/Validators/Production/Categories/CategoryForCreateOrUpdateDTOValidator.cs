using BikeStores.Contracts;
using BikeStores.Contracts.Production.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Validators.Production.Categories
{
    public class CategoryForCreateOrUpdateDTOValidator : AbstractValidator<CategoryForCreateOrUpdateDTO>
    {
        public CategoryForCreateOrUpdateDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(255);
        }
    }
}
