using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LAB19CreateAnAPI.Data
{
    public class Todo
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }

        [ForeignKey("TodoList")]
        public int ListId { get; set; }
    }
}
