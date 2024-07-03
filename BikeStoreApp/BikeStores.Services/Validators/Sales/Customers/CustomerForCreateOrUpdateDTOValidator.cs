using BikeStores.Contracts.Sales.Customers;
using BikeStores.Contracts.Sales.Staffs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Validators.Sales.Customers
{
    public class CustomerForCreateOrUpdateDTOValidator : AbstractValidator<CustomerForCreateOrUpdateDTO>
    {
        public CustomerForCreateOrUpdateDTOValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Phone).Matches("[0-9]{9}");
            RuleFor(x => x.City).MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Firstname).MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Lastname).MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Street).MinimumLength(3).MaximumLength(80);
            RuleFor(x => x.State).MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.City).MaximumLength(3).MaximumLength(50);
            RuleFor(x => x.ZipCode).Matches("[0-9]{2}-[0-9]{3}");
        }
    }
}
