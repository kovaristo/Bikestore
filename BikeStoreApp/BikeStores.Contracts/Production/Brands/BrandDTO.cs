using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Production.Brands
{
    /// <summary>
    /// Marka produktu
    /// </summary>
    public class BrandDTO : BaseAuditableDTO
    {
        /// <summary>
        /// Identyfikator marki
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nazwa marki
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Liczba produktow
        /// </summary>
        public int ProductsCount { get; set; }
    }
}
