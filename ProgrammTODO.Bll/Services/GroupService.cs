using Mapster;
using ProgrammTODO.Dal;
using ProgrammTODO.Dal.Models;
using Group = ProgrammTODO.Bll.Models.Group;
namespace ProgrammTODO.Bll.Services;



public class GroupService
{
	private readonly ApplicationContext _context;
	public GroupService(ApplicationContext context)
	{
		_context = context;
	}

	public void Create(Group model)
	{
		_context.Groups.Add(model.Adapt<GroupTaskDto>());
		_context.SaveChanges();
	}
	public IEnumerable<Group> GetAll()
	{
		var tasks = _context.Groups;
		var result = tasks.ProjectToType<Group>();

		return result;
	}
	//TODO: не выводит список задач?
    public void AddGroupTask(int idTask, int idGroup)
    {
		var task = _context.Tasks.FirstOrDefault(p => p.Id == idTask);
		var group = _context.Groups.FirstOrDefault(p => p.Id == idGroup);
		if (task != null && group != null)
        {
			task.GroupTaskDtoId = idGroup;
			group.Tasks.Add(task);

			_context.SaveChanges();
		}
	}

    public Group GetOneGroup(int idGroup)
    {
		var group = _context.Groups.FirstOrDefault(p => p.Id == idGroup);
		var groupResult = new Group();

		groupResult.Id = group.Id;
		groupResult.Name = group.Name;
		foreach (var taskDto in group.Tasks)
        {
			groupResult.Tasks.Add(taskDto.Adapt<Models.Task>());
		}

		return groupResult;

	}
}

