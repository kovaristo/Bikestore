using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Entities.Sales
{
    public class Staff : BaseAuditableEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public short Active { get; set; }
        public int? StoreId { get; set; }
        public int? ManagerId { get; set; }
        public virtual Staff Manager { get; set; }
        public virtual ICollection<Staff> Subordinate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Store Store { get; set; }
    }
}
