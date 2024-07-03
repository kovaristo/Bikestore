using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Production.Brands
{
    /// <summary>
    /// Dane marki do utworzenia
    /// </summary>
    public class BrandForCreateOrUpdateDTO
    {
        /// <summary>
        /// Nazwa marki
        /// </summary>
        public string Name { get; set; }
    }
}
