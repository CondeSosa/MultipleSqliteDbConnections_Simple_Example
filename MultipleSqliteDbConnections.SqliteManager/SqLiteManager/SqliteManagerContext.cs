
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultipleSqliteDbConnections.SqLiteManager.Models;

namespace MultipleSqliteDbConnections.SqLiteManager
{
    public class SqliteManagerContext : DbContext
    {
        private readonly string _sqliteDbName;

        public SqliteManagerContext(string sqliteDbName = "") 
        {
            _sqliteDbName = sqliteDbName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Databases");
                var fullPath = Path.Combine(pathToSave, _sqliteDbName);
                optionsBuilder.UseSqlite($"Data Source={fullPath}");
            }
       
        }

        public DbSet<Company> Company { get; set; }
    }
}
