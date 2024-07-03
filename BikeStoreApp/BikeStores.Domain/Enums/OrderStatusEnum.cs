using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Enums
{
    public enum OrderStatusEnum
    {
        New = 0,
        Accepted = 1, 
        Pending = 2,
        Completed = 3,
        Sent = 3, 
        Rejected = 4,
        Shipped = 5
    }
}
