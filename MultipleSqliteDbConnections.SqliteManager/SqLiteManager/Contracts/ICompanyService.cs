using MultipleSqliteDbConnections.SqLiteManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleSqliteDbConnections.SqliteManager.SqLiteManager.Contracts
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAll(string dbName);
        Task<Company> GetById(string dbName,int id);
        Task<int> Create(string dbName,Company company);
        Task Update(string dbName,Company company);
        Task Delete(string dbName, int id);
    }
}
