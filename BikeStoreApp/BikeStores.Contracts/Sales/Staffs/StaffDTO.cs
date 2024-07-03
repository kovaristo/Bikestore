using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BikeStores.Contracts.Sales.Staffs
{
    public class StaffDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public short Active { get; set; }
        public int? StoreId { get; set; }

        public StaffInfoDTO Manager { get; set; }
        public StaffInfoDTO[] Subordinate { get; set; }
    }
}
