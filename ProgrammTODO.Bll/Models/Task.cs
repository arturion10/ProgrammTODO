using System.ComponentModel.DataAnnotations;

namespace ProgrammTODO.Bll.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [MaxLength(200)]
        public string? Category { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime StartDateTime { get; set; } = DateTime.Now;
        public DateTime DeadLineСompleting { get; set; }

        public Task(string name, string description, string category, DateTime deadLineСompleting)
        {
            Name = name;

            if (description.Length >= 200)
            {
                throw new ArgumentOutOfRangeException();
            }
            Description = description;

            Category = category;

            DeadLineСompleting = deadLineСompleting;
        }

        public Task(int id, string? name, string? category, string? description, bool isCompleted, DateTime startDateTime, DateTime deadLineСompleting)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            IsCompleted = isCompleted;
            StartDateTime = startDateTime;
            DeadLineСompleting = deadLineСompleting;
        }

        public Task()
        {
        }
    }
}