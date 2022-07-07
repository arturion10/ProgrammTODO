using System.ComponentModel.DataAnnotations;

namespace ProgrammTODO.Bll.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime StartDateTime { get; set; } = DateTime.Now;
        public DateTime DeadLineСompleting { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? GroupTaskDtoId { get; set; }

        public Task(string name, string description, string category, DateTime deadLineСompleting)
        {
            Name = name;
            Description = description;
            Category = category;
            DeadLineСompleting = deadLineСompleting;
        }

        public Task(int id, string? name, string? category, string? description, bool isCompleted, DateTime startDateTime, DateTime deadLineСompleting, bool isDeleted)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            IsCompleted = isCompleted;
            StartDateTime = startDateTime;
            DeadLineСompleting = deadLineСompleting;
            IsDeleted = isDeleted;
        }

        public Task()
        {
        }
    }
}