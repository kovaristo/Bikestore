using BikeStores.Contracts.Sales.Orders;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Enums;
using Mapster;
using Microsoft.OpenApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Mapping.Sales
{
    public class OrderRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<OrderStatusEnum, string>()
                .Map(dest => dest, src => src.GetDisplayName());

            config.NewConfig<string, OrderStatusEnum>()
                .Map(dest => dest, src => src.GetEnumFromDisplayName<OrderStatusEnum>());

            config.NewConfig<Order, OrderDTO>()
                .Map(dest => dest.OrderStatus, src => src.OrderStatus.GetDisplayName());

            config.NewConfig<OrderForUpdateDTO, Order>()
                .Map(dest => dest.OrderStatus, src => src.OrderStatus.GetEnumFromDisplayName<OrderStatusEnum>())
                .Map(dest => dest.OrderItems, src => src.OrderItems.Adapt<OrderItem[]>());
        }
    }
}
