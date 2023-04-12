using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MultipleSqliteDbConnections.SqliteManager.SqLiteManager.Contracts;
using MultipleSqliteDbConnections.SqLiteManager.Models;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultipleSqliteDbConnections.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalDbCompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public LocalDbCompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/<LocalDbCompanyController/dbname>
        [HttpGet("{dbName}")]
        public async Task<ActionResult<List<Company>>> Get(string dbName)
        {
            return await _companyService.GetAll(dbName);
        }

        // GET api/<LocalDbCompanyController>/dbname/5
        [HttpGet("{dbName}/{id}")]
        public async Task<ActionResult<Company>> Get(string dbName,int id)
        {
            return await _companyService.GetById(dbName,id);
        }

        // POST api/<LocalDbCompanyController>
        [HttpPost("{dbName}")]
        public async Task<ActionResult> Post(string dbName, [FromBody] Company value)
        {
             await _companyService.Create(dbName, value);
            return Ok();
        }

        // PUT api/<LocalDbCompanyController>/5
        [HttpPut("{dbName}")]
        public async Task<ActionResult> Put(string dbName, [FromBody] Company value)
        {
            await _companyService.Update(dbName, value);
            return Ok();
        }

        // DELETE api/<LocalDbCompanyController>/5
        [HttpDelete("{dbName}/{id}")]
        public async Task<ActionResult> Delete(string dbName, int id)
        {
            await _companyService.Delete(dbName, id);
            return Ok();
        }
    }
}
