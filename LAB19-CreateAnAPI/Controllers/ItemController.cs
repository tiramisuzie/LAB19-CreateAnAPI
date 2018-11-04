using System.Collections.Generic;
using System.Linq;
using LAB19CreateAnAPI.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LAB19_CreateAnAPI.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly TodoContext _context;

        public ItemController(TodoContext context)
        {
            _context = context;
            if (_context.Todos.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Todos.Add(new Todo { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/todo
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<Todo> Get()
        {
            var items = _context.Todos;
            return items;
        }

        // GET api/todo/item/{id}
        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<Todo> GetById(long id)
        {
            var item = _context.Todos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST api/todo/item
        [HttpPost]
        public IActionResult Create(Todo item)
        {
            _context.Todos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        // PUT api/todo/item/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, Todo item)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.Todos.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/todo/item/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
