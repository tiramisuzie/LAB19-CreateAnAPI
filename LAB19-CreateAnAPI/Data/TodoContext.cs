using Microsoft.EntityFrameworkCore;

namespace LAB19CreateAnAPI.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoList> TodoList { get; set; }
    }
}
