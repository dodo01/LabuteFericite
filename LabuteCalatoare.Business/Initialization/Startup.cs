using System;
using System.Collections.Generic;
using System.Text;

namespace LabuteCalatoare.Business.Initialization
{
    public class Startup
    {
        private IServiceProvider _serviceProvider;
        private readonly DataBase.Initialization.Startup dbStartup = new DataBase.Initialization.Startup();
 
    }
}
