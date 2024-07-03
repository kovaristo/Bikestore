using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OrderRequest<T> where T : class
    {
        /// <summary>
        /// Pole sortowania
        /// </summary>
        public string? OrderField { get; set; }
        /// <summary>
        /// Kierunek sortowania
        /// </summary>
        public bool Ascending { get; set; } = true;
    }
}
