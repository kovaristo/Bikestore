using BikeStores.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Presentation.Controllers
{
    public abstract class BaseServiceController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IServiceManager ServiceManager;

        protected BaseServiceController(ILogger logger, IServiceManager serviceManager)
        {
            Logger = logger;
            ServiceManager = serviceManager;
        }

       
    }
}
