using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB19CreateAnAPI.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LAB19_CreateAnAPI.Controllers
{
    [Route("api/Todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;
        
        public TodoController(TodoContext context)
        {
            _context = context;
            if (_context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/todo
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/todo/{id}
        [HttpGet("{id}", Name ="GetTodo")]
        public ActionResult<TodoItem> GetById(long id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST api/todo
        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, TodoItem item)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }

    public class Value
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
