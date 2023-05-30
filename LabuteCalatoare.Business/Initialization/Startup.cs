using LabuteCalatoare.Business.Services.DatabaseServices;
using LabuteCalatoare.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LabuteCalatoare.Business.Initialization
{
    public class Startup
    {

        private static readonly DataBase.Initialization.Startup dbStartup = new DataBase.Initialization.Startup();

        public void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IHotelService, HotelService>();
        }
    }
}
