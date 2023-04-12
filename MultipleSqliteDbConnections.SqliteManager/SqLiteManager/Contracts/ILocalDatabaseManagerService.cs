using MultipleSqliteDbConnections.SqLiteManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleSqliteDbConnections.SqliteManager.SqLiteManager.Contracts
{
    public interface ILocalDatabaseManagerService
    {
        Task<SqliteManagerContext> CreateContextAsync(string dbName);
        Task<bool> CreateDatabase(string dbname);
         void DeleteDatabase(string dbname);
    }
}
