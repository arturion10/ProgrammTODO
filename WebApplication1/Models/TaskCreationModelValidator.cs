using FluentValidation;

namespace WebUI.Models
{
    public class TaskCreationModelValidator : AbstractValidator<TaskCreationModel>
    {
        public TaskCreationModelValidator()
        {
            RuleFor(x => x.Name).Length(1, 25).NotNull();
            RuleFor(x => x.Description).Length(1, 200);
            RuleFor(x => x.Category).Length(1, 25);
            RuleFor(x => x.DeadLineСompleting).GreaterThan(DateTime.Now);
        }
    }
}
