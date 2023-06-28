using FluentValidation;
using SoccerManager.Client.Models;

namespace SoccerManager.Client.Validators
{
  public class FanValidator : AbstractValidator<Fan>
  {
    public FanValidator()
    {
      RuleFor(f => f.Name).NotEmpty();
    }
  }
}
