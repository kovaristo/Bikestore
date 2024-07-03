using BikeStores.Contracts.Sales.Staffs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Validators.Sales.Staffs
{
    public class StaffForCreateOrUpdateDTOValidator : AbstractValidator<StaffForCreateOrUpdateDTO>
    {
        public StaffForCreateOrUpdateDTOValidator()
        {
            RuleFor(x => x.Active);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Firstname).MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.Lastname).MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Phone).Matches("[0-9]{9}"); ;
        }
    }
}
