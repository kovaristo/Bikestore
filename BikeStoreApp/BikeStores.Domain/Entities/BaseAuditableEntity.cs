using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Entities
{
    public abstract class BaseAuditableEntity
    {
        public BaseAuditableEntity()
        {
            CreatedBy = "system";
            WhenCreated = DateTime.Now;
        }

        public DateTime WhenCreated { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? WhenModified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
