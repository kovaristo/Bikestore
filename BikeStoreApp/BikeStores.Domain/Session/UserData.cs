using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Session
{
    public class UserData
    {
        public string Username { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
