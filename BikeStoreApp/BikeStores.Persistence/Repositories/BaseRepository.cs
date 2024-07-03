using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly RepositoryDbContext DbContext;

        public BaseRepository(RepositoryDbContext dbContext) 
        { 
            DbContext = dbContext; 
        }
    }
}
