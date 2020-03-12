using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndyBooks.Models;
using IndyBooks.ViewModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndyBooks.Controllers
{
    [Route("api/[controller]")]
    public class WriterController : Controller
    {
        private IndyBooksDataContext _db;
        public WriterController(IndyBooksDataContext db) { _db = db; }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var writer = _db.Writers;
            return Json(writer);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var writer = _db.Writers.Where(w => w.Id == id).Select(w=> new { id = w.Id, name = w.Name });                
            return Json(writer);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post(Writer writer)
        {
            _db.Writers.Add(writer);
            return Accepted();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, Writer writer)
        {
            Writer author = _db.Writers.SingleOrDefault(w => w.Id == id);
            author.Name = writer.Name;
            author.Id = id;
            return Accepted();            
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
