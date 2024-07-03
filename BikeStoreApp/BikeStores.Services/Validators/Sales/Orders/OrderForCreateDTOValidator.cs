using BikeStores.Contracts.Sales.Orders;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Exceptions.Sales;
using BikeStores.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStores.Services.Validators.Sales.Orders
{
    public class OrderForCreateDTOValidator : AbstractValidator<OrderForCreateDTO>
    {
        private readonly IRepositoryManager _repositoryManager;

        public OrderForCreateDTOValidator(IRepositoryManager repositoryManager) : base()
        {
            this._repositoryManager = repositoryManager;

            RuleFor(x => x.RequiredDate).Must((m, f) => m.OrderDate <= m.RequiredDate);
            RuleFor(x => x.StaffId).Custom((id, ctx) =>
            {

                var staffs = _repositoryManager.StaffsRepository.GetByStoreId(ctx.InstanceToValidate.StoreId, CancellationToken.None).Result;
                if (!staffs.Any(x => x.Id == id))
                    ctx.AddFailure($"Osoba {id} nie należy do personelu sklepu {ctx.InstanceToValidate.StoreId}");
            });
        }

    }
}
