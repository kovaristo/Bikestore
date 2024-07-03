using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Entities.Sales
{
    public class Customer : BaseAuditableEntity
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
