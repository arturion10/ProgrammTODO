namespace ProgrammTODO.Dal.Models;

public class TaskDto
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Category { get; set; }
	public string? Description { get; set; }
	public bool IsCompleted { get; set; }
	public DateTime StartDateTime { get; set; }
	public DateTime DeadLineСompleting { get; set; }
	public bool IsDeleted { get; set; }
	public int? GroupTaskDtoId { get; set; }
}