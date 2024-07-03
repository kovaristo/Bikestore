using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Production.Brands
{
    /// <summary>
    /// Parametry filtowania marki
    /// </summary>
    public class BrandFilterRequest
    {
        /// <summary>
        /// Nazwa marki
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
