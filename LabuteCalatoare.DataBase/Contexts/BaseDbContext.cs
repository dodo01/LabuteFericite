using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LabuteCalatoare.DataBase.Contexts
{
    public class BaseDbContext: DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public BaseDbContext(DbContextOptions options,ILoggerFactory loggerFactory = null) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder
                .UseLoggerFactory(_loggerFactory)
                .EnableDetailedErrors()
                .UseLazyLoadingProxies()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        }


        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
