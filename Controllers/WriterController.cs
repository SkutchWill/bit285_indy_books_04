using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndyBooks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndyBooks.Controllers
{

    [Route("api/[controller]")]
    public class WriterController : Controller
    {
        //inject the db 
        private IndyBooksDataContext _db;
        public WriterController(IndyBooksDataContext db) { _db = db; }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var writer = _db.Writers.Select(w => new { name = w.Name });
            //_db.Add<Writer>(writer);

            return Content("Writer");
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var writer = _db.Writers.Select(w => new { id = w.Id, name = w.Name });
            return Content("Writer: " + id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
}
