using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class TaskCreationModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime DeadLineСompleting { get; set; }
    }
}
