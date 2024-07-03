using BikeStores.Domain.Session;
using BikeStores.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Helpers
{
    internal class InMemoryDbContextFactory
    {
        public static RepositoryDbContext GetInMemoryNotAuthenticatedContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryDbContext>()
                .UseInMemoryDatabase("BikeStores");
            return new RepositoryDbContext(optionsBuilder.Options, new UserData() { IsAuthenticated = false });
        }

        public static RepositoryDbContext GetInMemoryAuthenticatedContext(string username)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryDbContext>()
                .UseInMemoryDatabase("BikeStores");
            return new RepositoryDbContext(optionsBuilder.Options, new UserData() { IsAuthenticated = true, Username = username });
        }
    }
}
