using System;
using Microsoft.Extensions.DependencyInjection;

namespace LabuteCalatoare.DataBase.Initialization
{
    public class Startup
    {
       public void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<>
        }
    }
}
