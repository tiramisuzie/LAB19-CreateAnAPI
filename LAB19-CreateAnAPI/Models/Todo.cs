using System.ComponentModel.DataAnnotations.Schema;

namespace LAB19CreateAnAPI.Data
{
    public class Todo
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }

        [ForeignKey("TodoList")]
        public long ListId { get; set; }

        public TodoList TodoList { get; set; }
    }
}
