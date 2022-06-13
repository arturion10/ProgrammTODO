using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammTODO
{
    public class TaskClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(200)]
        public string Category { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime StartDateTime { get; set; } = DateTime.Now;

        public TaskClass(string name, string description, string category)
        {
            Name = name;
            if (description.Length >= 200)
            {
                Console.WriteLine("Описание задачи не может превышать 200 символов!");
            }
            Description = description;
            Category = category;
        }
    }
}