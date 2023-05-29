using System;
using System.Data.Common;
using LabuteCalatoare.DataBase.Contexts;
using LabuteCalatoare.DataBase.Repositories;
using LabuteCalatoare.DataBase.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LabuteCalatoare.DataBase.Initialization
{
    public class Startup
    {

       public void ConfigureServices(IServiceCollection services, string connectionString)
        {
            MySql.Data.MySqlClient.MySqlConnectionStringBuilder a = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();
            services.AddDbContext<LabuteCalatoareContext>(options =>options.UseMySQL(connectionString).EnableDetailedErrors().EnableSensitiveDataLogging(), ServiceLifetime.Transient);

            services.AddTransient<IHotelRepository, HotelRepository>();

        }
    }
}
