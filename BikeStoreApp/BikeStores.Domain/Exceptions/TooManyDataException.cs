using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Exceptions
{
    public class TooManyDataException : BadRequestException
    {
        public TooManyDataException(int totalRecords) : base($"Liczba rekordów {totalRecords} jest zbyt duża")
        {
        }
    }
}
