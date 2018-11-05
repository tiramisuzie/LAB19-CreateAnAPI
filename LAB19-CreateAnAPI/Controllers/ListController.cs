using System.Collections.Generic;
using System.Linq;
using LAB19CreateAnAPI.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LAB19_CreateAnAPI.Controllers
{
    [Route("api/todolist")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly TodoContext _context;

        public ListController(TodoContext context)
        {
            _context = context;
            if (_context.TodoList.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoList.Add(new TodoList { Name = "DefaultList" });
                _context.SaveChanges();
            }
        }

        // GET: api/todo/list
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<TodoList> Get()
        {
            var items = _context.TodoList;
            return items;
        }

        // GET api/todo/list/{id}
        [HttpGet("{id}", Name = "GetList")]
        public ActionResult<TodoList> GetById(long id)
        {
            var item = _context.TodoList.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST api/todo/list
        [HttpPost]
        public IActionResult Create(TodoList list)
        {
            _context.TodoList.Add(list);
            _context.SaveChanges();

            return CreatedAtRoute("GetList", new { id = list.Id }, list);
        }

        // PUT api/todo/list/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, TodoList item)
        {
            var todo = _context.TodoList.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            
            todo.Name = item.Name;

            _context.TodoList.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/todo/list/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todoList = _context.TodoList.Find(id);
            if (todoList == null)
            {
                return NotFound();
            }
            _context.TodoList.Remove(todoList);

            IQueryable<Todo> todos = _context.Todos.Where(x => x.ListId == id);
            if (todos != null && todos.Count() > 0)
            {
                _context.Todos.RemoveRange(todos);
            }

            _context.SaveChanges();
            return NoContent();
        }
    }
}
