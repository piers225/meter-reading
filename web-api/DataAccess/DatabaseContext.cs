
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace web_api.DataAccess 
{ 
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<MeterReading> MeterReadings { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
        : base(options)
        {
            
        }
        
    }
}