using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BikeStores.Contracts
{
    /// <summary>
    /// Parametry stronicowania
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingRequest<T> : OrderRequest<T> where T : class 
    {
        /// <summary>
        /// Index strony
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// Rozmiar strony
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Index pierwszego rekordu strony
        /// </summary>
        /// <returns></returns>
        public int StartIndex()
        {
            return (PageIndex - 1) * PageSize;
        }
    }
}
