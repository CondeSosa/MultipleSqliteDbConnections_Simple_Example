using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using MultipleSqliteDbConnections.SqlManager.Contracts;
using MultipleSqliteDbConnections.SqlManager.Models;

namespace MultipleSqliteDbConnections.SqlManager.Services
{
    public class DatabasesService : IDatabasesService
    {
        private readonly SqlManagerContext _sqlManagerContext;

        public DatabasesService(SqlManagerContext sqlManagerContext)
        {
            _sqlManagerContext = sqlManagerContext;
        }

        public async Task<string> Create(string name)
        {
            var data = new Databases
            {
                Id = Guid.NewGuid().ToString(),
                Name = name 
            };
             await _sqlManagerContext.databases.AddAsync(data);
             await _sqlManagerContext.SaveChangesAsync();

            return data.Id;
        }

        public async Task Delete(string id)
        {
           var data =  await _sqlManagerContext.databases.FindAsync(id);
           _sqlManagerContext.databases.Remove(data);
           await _sqlManagerContext.SaveChangesAsync();
        }

        public async Task<List<Databases>> GetAll()
        {
            return await _sqlManagerContext.databases.ToListAsync();
        }

        public async Task<Databases> GetById(string id)
        {
            return await _sqlManagerContext.databases.FindAsync(id);
        }
    }
}
