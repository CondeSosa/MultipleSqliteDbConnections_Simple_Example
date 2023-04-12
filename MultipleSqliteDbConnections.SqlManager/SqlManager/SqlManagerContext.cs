using Microsoft.EntityFrameworkCore;
using MultipleSqliteDbConnections.SqlManager.Models;

namespace MultipleSqliteDbConnections.SqlManager
{
    public class SqlManagerContext : DbContext
    {
        public SqlManagerContext(DbContextOptions options) : base(options)
        {
        }

         public DbSet<Databases> databases { get; set; }

    }
}
