using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts
{
    public abstract class BaseAuditableDTO
    {
        /// <summary>
        /// Data utworzenia
        /// </summary>
        public DateTime WhenCreated { get; set; }
        /// <summary>
        /// Kto utworzył
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;
        /// <summary>
        /// Data modyfikacji
        /// </summary>
        public DateTime? WhenModified { get; set; }
        /// <summary>
        /// Kto zmodyfikował
        /// </summary>
        public string? ModifiedBy { get; set; }
    }
}
