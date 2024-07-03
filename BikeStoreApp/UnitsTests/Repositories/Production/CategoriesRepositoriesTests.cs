using BikeStores.Contracts.Production.Categories;
using BikeStores.Contracts.Sales.Customers;
using BikeStores.Contracts.Sales.Orders;
using BikeStores.Domain.Session;
using BikeStores.Persistence;
using BikeStores.Persistence.Repositories.Production;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using UnitTests.Helpers;

namespace UnitTests.Repositories.Production
{
    [TestClass]
    public class CategoriesRepositoriesTests
    {

        [TestMethod]
        public void GetAllCategoriesAuthenticated()
        {
            using (var dbContext = InMemoryDbContextFactory.GetInMemoryAuthenticatedContext("sampleuser"))
            {
                var categoriesRepo = new CategoriesRepository(dbContext);
                var result = categoriesRepo.GetByNameAsync("", nameof(CategoryDTO.Name), true, 0, 10, CancellationToken.None).Result;

                Assert.IsNotNull(result);
            }
        }
    }
}