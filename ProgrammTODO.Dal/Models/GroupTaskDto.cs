using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammTODO.Dal.Models
{
    public class GroupTaskDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<TaskDto> Tasks { get; set; } = new();
    }
}
