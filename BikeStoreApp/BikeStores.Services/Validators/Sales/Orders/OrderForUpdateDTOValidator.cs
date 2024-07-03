using BikeStores.Contracts.Sales.Orders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Validators.Sales.Orders
{
    public class OrderForUpdateDTOValidator : AbstractValidator<OrderForUpdateDTO>
    {
        public OrderForUpdateDTOValidator()
        {
            RuleFor(x => x.RequiredDate).Must((m, f) => m.ShippedDate <= m.RequiredDate);
        }
    }
}
