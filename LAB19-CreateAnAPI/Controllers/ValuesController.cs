using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LAB19_CreateAnAPI.Controllers
{
    [Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    // GET: api/<controller>
    [HttpGet]
    [Produces("application/json")]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return $"value {id}";
    }

    // POST api/<controller>
    [HttpPost]
    public IActionResult Post([FromBody]Value value)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

            return CreatedAtAction("Get", new { id = value.Id });
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
    public class Value
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
