using BikeStores.Contracts.Production.Brands;
using BikeStores.Domain.Entities.Production;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Mapping.Production
{
    public class BrandRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Brand, BrandDTO>()
                .Map(dest => dest.ProductsCount, src => src.Products.Count());

        }
    }
}
