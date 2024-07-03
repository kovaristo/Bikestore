using BikeStores.Contracts.Sales.Stores;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Validators.Sales.Stores
{
    public class StoreForCreateOrUpdateDTOValidator : AbstractValidator<StoreForCreateOrUpdateDTO>
    {
        public StoreForCreateOrUpdateDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(255);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Phone).Matches("[0-9]{9}");
            RuleFor(x => x.Street).MinimumLength(3).MaximumLength(80);
            RuleFor(x => x.State).MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.City).MaximumLength(3).MaximumLength(50);
            RuleFor(x => x.ZipCode).Matches("[0-9]{2}-[0-9]{3}");
        }
    }
}
