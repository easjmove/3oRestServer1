using JsonFruit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestServer1.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestServer1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        public FruitManager _manager = new FruitManager();

        // GET: api/<FruitController>
        [HttpGet]
        public IEnumerable<Fruit> Get()
        {
            return _manager.GetList(null);
        }

        // GET api/<FruitController>/5
        [HttpGet("{substring}")]
        public IEnumerable<Fruit> Get(string substring)
        {
            return _manager.GetList(substring);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("Name")]
        public ActionResult<List<Fruit>> GetFromUrl([FromQuery] string substring)
        {
            List<Fruit> result = _manager.GetList(substring);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<FruitController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FruitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FruitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
