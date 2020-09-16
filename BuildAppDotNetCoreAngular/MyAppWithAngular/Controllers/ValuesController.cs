using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAppWithAngular.Models;

namespace MyAppWithAngular.Controllers
{
    
    [ApiController, Authorize, Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private DatabaseContext _dbContext;

        public ValuesController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetValues()
        {
            List<Value> values = await _dbContext.Values.ToListAsync();

            return Ok(values);
        }

        
        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetValue(int id)
        {
            Value value = await _dbContext.Values.FindAsync(id);

            if (value == null)
                return NotFound();

            return Ok(value);
        }
    }
}
