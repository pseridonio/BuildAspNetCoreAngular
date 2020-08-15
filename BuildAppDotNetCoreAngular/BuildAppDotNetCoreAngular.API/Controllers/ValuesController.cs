using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildAppDotNetCoreAngular.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildAppDotNetCoreAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DatabaseContext _dbContext;

        public ValuesController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetValues()
        {
            List<Value> values = _dbContext.Values.ToList();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            Value value = _dbContext.Values.Find(id);

            if (value == null)
                return NotFound();

            return Ok(value);
        }
    }
}
