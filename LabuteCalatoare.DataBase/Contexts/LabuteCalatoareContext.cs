using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LabuteCalatoare.DataBase.Contexts
{
    public class LabuteCalatoareContext : BaseDbContext
    {
        public LabuteCalatoareContext(DbContextOptions options, ILoggerFactory loggerFactory = null): base(options, loggerFactory)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer("");  //take the connection string from config file
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
