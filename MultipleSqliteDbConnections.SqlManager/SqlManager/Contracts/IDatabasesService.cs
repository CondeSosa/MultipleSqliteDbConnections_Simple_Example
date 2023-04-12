

using MultipleSqliteDbConnections.SqlManager.Models;

namespace MultipleSqliteDbConnections.SqlManager.Contracts
{
    public interface IDatabasesService
    {
        public Task<List<Databases>> GetAll();
        public Task<Databases> GetById(string id);
        public Task<string> Create(string name);
        public Task Delete(string id);

    }
}
