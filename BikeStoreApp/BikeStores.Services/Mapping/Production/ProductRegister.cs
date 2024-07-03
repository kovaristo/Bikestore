using BikeStores.Contracts.Production.Products;
using BikeStores.Domain.Entities.Production;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Mapping.Production
{
    public class ProductRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductDTO>();
        }
    }
}
