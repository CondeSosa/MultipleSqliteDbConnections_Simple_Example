using Microsoft.EntityFrameworkCore;
using MultipleSqliteDbConnections.SqliteManager.SqLiteManager.Contracts;
using MultipleSqliteDbConnections.SqLiteManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MultipleSqliteDbConnections.SqliteManager.SqLiteManager.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ILocalDatabaseManagerService _localDatabaseManager;

        public CompanyService(ILocalDatabaseManagerService localDatabaseManager)
        {
            _localDatabaseManager = localDatabaseManager;
        }

        public async Task<int> Create(string dbName, Company company)
        {
            using (var _context = await _localDatabaseManager.CreateContextAsync(dbName))
            {
                
                await _context.Company.AddAsync(company);
                await _context.SaveChangesAsync();
                return company.Id;
            }
        }

        public async Task Delete(string dbName, int id)
        {
            using (var _context = await _localDatabaseManager.CreateContextAsync(dbName))
            {

                var  data = await _context.Company.FindAsync(id);
                _context.Company.Remove(data);
                await _context.SaveChangesAsync();
            
            }
        }

        public async Task<List<Company>> GetAll(string dbName)
        {
            using (var _context = await _localDatabaseManager.CreateContextAsync(dbName))
            {
                return await _context.Company.ToListAsync();

            }
        }

        public async Task<Company> GetById(string dbName, int id)
        {
            using (var _context = await _localDatabaseManager.CreateContextAsync(dbName))
            {
                return await _context.Company.FindAsync(id);
              
            }
        }

        public async Task Update(string dbName, Company company)
        {
            using (var _context = await _localDatabaseManager.CreateContextAsync(dbName))
            {

                var data = await _context.Company.FindAsync(company.Id);
                if (data != null)
                {
                    data.PhoneNumber = company.PhoneNumber;
                    data.Name = company.Name;
                    data.Address = company.Address;
                    data.IdNumber = company.IdNumber;
                    data.IdType = company.IdType;

                    _context.Company.Update(data);
                    await _context.SaveChangesAsync();
                }

            }
        }
    }
}
