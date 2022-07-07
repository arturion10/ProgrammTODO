using Microsoft.AspNetCore.Mvc;
using ProgrammTODO.Bll.Services;
using WebUI.Models;
using Group = ProgrammTODO.Bll.Models.Group;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _service;
        public GroupController(GroupService service)
        {
            _service = service;
        }
        [HttpPost("CreateGroup")]
        public ActionResult CreateTask(GroupCreationModel model)
        {
            _service.Create(new Group(model.Name));
            return Ok();
        }
        [HttpGet("AllGroup")]
        public ActionResult<IEnumerable<Group>> GetAllGroup()
        {
            return _service.GetAll().OrderBy(x => x.Name).ToList();
        }
        [HttpPost("AddGroupTask")]
        public void AddGroupTask(int idTask, int idGroup)
        {
            _service.AddGroupTask(idTask, idGroup);
        }
        [HttpGet("GetOneGroup")]
        public ActionResult<Group> GetOneGroup(int IdGroup)
        {
            return _service.GetOneGroup(IdGroup);
        }
    }
}
