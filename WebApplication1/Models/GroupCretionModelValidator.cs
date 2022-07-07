using FluentValidation;

namespace WebUI.Models
{
    public class GroupCreationModelValidator : AbstractValidator<GroupCreationModel>
    {
        public GroupCreationModelValidator()
        {
            RuleFor(x => x.Name).Length(1, 25).NotNull();
        }
    }
}