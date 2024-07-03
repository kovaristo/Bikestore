using BikeStores.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Entities.Production
{
    public class Product : BaseAuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        public short ModelYear { get; set; }
        public decimal ListPrice { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
