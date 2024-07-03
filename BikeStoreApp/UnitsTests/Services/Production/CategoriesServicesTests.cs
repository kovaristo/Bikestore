using BikeStores.Contracts.Production.Categories;
using BikeStores.Domain.Exceptions.Production;
using BikeStores.Domain.Repositories;
using BikeStores.Persistence.Repositories.Production;
using BikeStores.Services.Abstractions.Production;
using BikeStores.Services.Implementations.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Helpers;
using Moq;
using BikeStores.Domain.Repositories.Production;
using BikeStores.Domain.Entities.Production;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace UnitTests.Services.Production
{
    [TestClass]
    public class CategoriesServicesTests
    {
        [TestMethod]
        public void DeleteNotExistsCategoryShouldFail()
        {
            var repoManagerMock = new Mock<IRepositoryManager>();
            
            var categoriesRepoMock = new Mock<ICategoriesRepository>();
            
            categoriesRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), CancellationToken.None))
                .Returns(Task.FromResult<Category>(null));

            repoManagerMock.Setup(x=>x.CategoriesRepository).Returns(categoriesRepoMock.Object);

            var categoriesService = new CategoriesService(repoManagerMock.Object);

            Assert.ThrowsException<CategoryNotFoundException>(() =>
            {
                categoriesService.DeleteCategoryAsync(123, CancellationToken.None).GetAwaiter().GetResult();
            });
        }
    }
}
