using BikeStores.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services
{
    public abstract class BaseService
    {
        protected readonly IRepositoryManager RepositoryManager;

        public BaseService(IRepositoryManager repositoryManager) => RepositoryManager = repositoryManager;
    }
}
