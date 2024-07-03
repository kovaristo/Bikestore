using BikeStores.Contracts.Production.Categories;
using BikeStores.Domain.Entities.Production;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.Mapping.Production
{
    public class CategoryRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category,CategoryDTO>()
                .Map(dest => dest.ProductsCount, src => src.Products.Count());

        }
    }
}
