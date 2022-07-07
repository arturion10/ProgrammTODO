using Microsoft.EntityFrameworkCore;
using ProgrammTODO.Dal.Models;

namespace ProgrammTODO.Dal
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TaskDto> Tasks { get; set; } = null!;
        public DbSet<GroupTaskDto> Groups { get; set; } = null!;
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Tasks.db");
        }
        //TODO: Нужно добавить дефолтную строку в таблицу Groups(Id = 1, Name = "Входящие")
    }
}
