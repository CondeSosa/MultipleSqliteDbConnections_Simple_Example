using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using MultipleSqliteDbConnections.SqliteManager.SqLiteManager.Contracts;
using MultipleSqliteDbConnections.SqLiteManager;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultipleSqliteDbConnections.SqliteManager.SqLiteManager.Services
{
    public class LocalDatabaseManagerService : ILocalDatabaseManagerService
    {
      

        public LocalDatabaseManagerService()
        {
          
        }

        public async Task<SqliteManagerContext> CreateContextAsync(string dbName)
        {
                var databaseName = $"{dbName}.db";
                var context = new SqliteManagerContext(databaseName);
                context.Database.Migrate();
                return context;
           
        }

        public async Task<bool> CreateDatabase(string dbname)
        {
         
           var context = await CreateContextAsync(dbname);

           if(context != null) 
            {
                context.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteDatabase(string dbname)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Databases");
            var fileName = $"{dbname}.db";
            var fullPath = Path.Combine(basePath, fileName);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
