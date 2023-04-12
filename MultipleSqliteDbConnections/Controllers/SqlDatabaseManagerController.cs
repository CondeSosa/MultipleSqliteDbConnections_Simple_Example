using Microsoft.AspNetCore.Mvc;
using MultipleSqliteDbConnections.SqliteManager.SqLiteManager.Contracts;
using MultipleSqliteDbConnections.SqlManager.Contracts;
using MultipleSqliteDbConnections.SqlManager.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultipleSqliteDbConnections.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlDatabaseManagerController : ControllerBase
    {
        private readonly IDatabasesService _databasesService;
        private readonly ILocalDatabaseManagerService _localDatabaseManagerService;

        public SqlDatabaseManagerController(IDatabasesService databasesService, ILocalDatabaseManagerService localDatabaseManagerService)
        {
            _databasesService = databasesService;
            _localDatabaseManagerService = localDatabaseManagerService;
        }

        // GET: api/<SqlDatabaseManagerController>
        [HttpGet]
        public async Task<ActionResult<List<Databases>>> Get()
        {
            return Ok(await _databasesService.GetAll());
        }

        // GET api/<SqlDatabaseManagerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Databases>> Get(string id)
        {
            return Ok(await _databasesService.GetById(id));
        }

        // POST api/<SqlDatabaseManagerController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] string name)
        {
            var id = await _databasesService.Create(name);
          if( await _localDatabaseManagerService.CreateDatabase(id))
            return Ok();

            return NotFound();
        }


        // DELETE api/<SqlDatabaseManagerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _databasesService.Delete(id);
            _localDatabaseManagerService.DeleteDatabase(id);
            return Ok();
        }
    }
}
