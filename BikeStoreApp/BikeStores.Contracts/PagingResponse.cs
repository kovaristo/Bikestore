using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts
{
    public class PagingResponse<T> where T : class
    {
        /// <summary>
        /// Numer strony
        /// </summary>
        public int PageIndex { get; set; } = 0;
        /// <summary>
        /// Rozmiar strony
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// Liczba wszystkich rekordow
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// Liczba wszystkich stron
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// Dane
        /// </summary>
        public T[] Data { get; set; }
        
        public PagingResponse(T[] data, int totalRecords, int pageIndex, int pageSize)
        {
            this.Data = data;
            this.TotalRecords = totalRecords;
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.TotalPages = totalRecords / pageSize + ((totalRecords % pageSize == 0) ? 0 : 1);
        }

        public PagingResponse(T[] data, int totalRecords, PagingRequest<T> pagingRequest)
        {
            this.Data = data;
            this.TotalRecords = totalRecords;
            this.PageSize = pagingRequest.PageSize;
            this.PageIndex = pagingRequest.PageIndex;
            this.TotalPages = totalRecords / pagingRequest.PageSize + ((totalRecords % pagingRequest.PageSize == 0) ? 0 : 1);
        }
    }
}
