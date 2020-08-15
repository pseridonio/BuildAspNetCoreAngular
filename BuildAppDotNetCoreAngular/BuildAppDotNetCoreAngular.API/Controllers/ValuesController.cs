using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildAppDotNetCoreAngular.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetValues()
        {
            List<Value> values = await _dbContext.Values.ToListAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            Value value = await _dbContext.Values.FindAsync(id);

            if (value == null)
                return NotFound();

            return Ok(value);
        }
    }
}
