using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammTODO.Bll.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Task> Tasks { get; set; } = new();
        public Group(string? name)
        {
            Name = name;
        }
        public Group() { }
    }
}
