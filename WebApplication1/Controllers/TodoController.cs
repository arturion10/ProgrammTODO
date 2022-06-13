using Microsoft.AspNetCore.Mvc;
using ProgrammTODO;
using WebUI.Models;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TaskDbLogic _logic;
        public TodoController()
        {
            _logic = new TaskDbLogic();
        }

        [HttpPost]
        public ActionResult CreateTask(TaskCreationModel model)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var task = new TaskClass(model.Name, model.Description, model.Category);
                db.Tasks.Add(task);
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskClass>> GetAllTask()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tasks = db.Tasks.ToList();
                return tasks;
            }
        }
        [HttpGet("ActiveTask")]
        public ActionResult<IEnumerable<TaskClass>> GetActiveTask()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tasks = db.Tasks.ToList().Where(t => t.IsCompleted == false).ToList();
                return tasks;
            }
        }
        [HttpPost("ChangeStatus")]
        public void ChangeTaskStatus(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tasks = db.Tasks.FirstOrDefault(p => p.Id == id);
                if (tasks != null)
                {
                    if(tasks.IsCompleted == false)
                        tasks.IsCompleted = true;
                    else
                        tasks.IsCompleted = false;
                    
                    db.SaveChanges();
                }
            }
        }
        [HttpGet("TaskInTime")]
        public ActionResult<IEnumerable<TaskClass>> LookTasksInTime(int year, int month, int day)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tasks = db.Tasks.ToList().Where(p => p.StartDateTime.Year == year &&
                                                         p.StartDateTime.Month == month &&
                                                         p.StartDateTime.Day == day);
                return tasks.ToList();
            }
        }
    }
}