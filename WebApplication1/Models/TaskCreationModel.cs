using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class TaskCreationModel
    {
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
