using BikeStores.Common.Attributes;

namespace BikeStores.Contracts.Production.Categories
{
    public class CategoryDTO : BaseAuditableDTO
    {
        /// <summary>
        /// Category's identifier
        /// </summary>
        [Sortable(SourceField = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Category's name
        /// </summary>
        [Sortable(SourceField = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Product in category count
        /// </summary>
        public int ProductsCount { get; set; }
    }
}