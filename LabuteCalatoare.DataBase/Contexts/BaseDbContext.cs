using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace LabuteCalatoare.DataBase.Contexts
{
    public class BaseDbContext: DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        private MySqlConnection _conn;

        public BaseDbContext(DbContextOptions options, MySqlConnection conn, ILoggerFactory loggerFactory = null) : base(options)
        {
            _loggerFactory = loggerFactory;
            _conn = conn;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseMySQL(_conn.ConnectionString);
            dbContextOptionsBuilder
                .UseLoggerFactory(_loggerFactory).EnableDetailedErrors().UseLazyLoadingProxies().UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        }


        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
