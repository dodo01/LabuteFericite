using System;
using System.Collections.Generic;
using System.Text;
using LabuteCalatoare.Business.Services.DatabaseServices;
using LabuteCalatoare.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LabuteCalatoare.Business.Initialization
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IImagesService, ImagesService>();
        }
    }
}
