using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Response
{
    public class DataPart
    {
        public static DataPart<T> Create<T>(IEnumerable<T> data, int total) where T: class
        {
            return new DataPart<T>(data, total);
        }
    }

    public class DataPart<T> : DataPart where T : class
    {
        public T[] Data { get; set; }
        public int Total { get; set; }

        public DataPart(IEnumerable<T> data, int total)
        {
            this.Data = data.ToArray();
            this.Total = total;
        }
    }
}
