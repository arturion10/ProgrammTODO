using Mapster;
using ProgrammTODO.Dal;
using ProgrammTODO.Dal.Models;
using Task = ProgrammTODO.Bll.Models.Task;
namespace ProgrammTODO.Bll.Services;


public class TaskService
{
	private readonly ApplicationContext _context;

	public TaskService(ApplicationContext context)
	{
		_context = context;
	}

	public IEnumerable<Task> GetActive()
	{
        var tasks = _context.Tasks.Where(t => t.IsCompleted == false);
		var result = tasks.ProjectToType<Task>();

		return result;
	}
	public IEnumerable<Task> GetAll()
    {
		var tasks = _context.Tasks;
		var result = tasks.ProjectToType<Task>();

		return result;
	}
	public IEnumerable<Task> LookInTime(int year, int month, int day)
	{
		var tasks = _context.Tasks
			.Where(t => t.StartDateTime.Year == year &&
						t.StartDateTime.Month == month &&
						t.StartDateTime.Day == day);

		var result = tasks.ProjectToType<Task>();

		return result;
	}
	public IEnumerable<Task> LookDeadLine(int day, int month, int year)
	{
		var tasks = _context.Tasks
			.Where(t => t.DeadLineСompleting.Year == year &&
						t.DeadLineСompleting.Month == month &&
						t.DeadLineСompleting.Day == day);

		var result = tasks.ProjectToType<Task>();

		return result;
	}
	public void Create(Task model)
	{
		_context.Tasks.Add(new TaskDto()
		{
			Category = model.Category,
			Description = model.Description,
			Id = model.Id,
			IsCompleted = model.IsCompleted,
			Name = model.Name,
			StartDateTime = model.StartDateTime,
			DeadLineСompleting = model.DeadLineСompleting
	});
		_context.SaveChanges();
	}
    public void ChangeStaus(int id)
    {
		var tasks = _context.Tasks.FirstOrDefault(p => p.Id == id);
		if (tasks != null)
		{
			if (tasks.IsCompleted == false)
				tasks.IsCompleted = true;
			else
				tasks.IsCompleted = false;

			_context.SaveChanges();
		}
	}
    public void Delite(int id)
    {
        var task = _context.Tasks.FirstOrDefault(p => p.Id == id);
		if(task != null)
        {
			_context.Remove(task);
			_context.SaveChanges();
		}
	}
 }