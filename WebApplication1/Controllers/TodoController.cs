using Microsoft.AspNetCore.Mvc;
using ProgrammTODO.Bll.Services;
using WebUI.Models;
using Task = ProgrammTODO.Bll.Models.Task;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TaskService _service;
        public TodoController(TaskService service)
        {
            _service = service;
        }

        [HttpPost("CreateTask")]
        public ActionResult CreateTask(TaskCreationModel model)
        {
            _service.Create(new Task(model.Name, model.Description, model.Category, model.DeadLineÑompleting));
            return Ok();
        }

        [HttpGet("AllTask")]
        public ActionResult<IEnumerable<Task>> GetAllTask()
        {
            return _service.GetAll().ToList();
        }

        [HttpGet("ActiveTask")]
        public ActionResult<IEnumerable<Task>> GetActiveTasks()
        {
            return _service.GetActive().ToList();
        }

        [HttpPost("ChangeStatus")]
        public void ChangeTaskStatus(int id)
        {
            _service.ChangeStaus(id);
        }

        [HttpGet("TaskInTime")]
        public ActionResult<IEnumerable<Task>> LookTasksInTime(int year, int month, int day)
        {
            return _service.LookInTime(year, month, day).ToList();
        }

        [HttpGet("DeadLineInTime")]
        public ActionResult<IEnumerable<Task>> LookDeadLineInTime(int day, int month, int year)
        {
            return _service.LookDeadLine(day, month, year).ToList();
        }

        [HttpPost("Delite")]
        public void DeliteTask(int id)
        {
            _service.Delite(id);
        }

        [HttpPost("EditTask")]
        public void EditTask(int id, TaskCreationModel model)
        {
            _service.EditTask(id, new Task(model.Name, model.Description, model.Category, model.DeadLineÑompleting));
        }

        [HttpPost("SoftDelete")]
        public void SoftTaskDelete(int id)
        {
            _service.SoftDelete(id);
        }

        [HttpPost("SoftRecovery")]
        public void SoftTaskRecovery(int id)
        {
            _service.SoftRecovery(id);
        }

    }
}