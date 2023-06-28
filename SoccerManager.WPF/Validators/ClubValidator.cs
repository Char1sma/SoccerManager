using FluentValidation;
using SoccerManager.Client.Models;

namespace SoccerManager.Client.Validators
{
  public class ClubValidator : AbstractValidator<Club>
  {
    public ClubValidator()
    {
      RuleFor(c => c.Name).NotEmpty();
      RuleFor(c => c.City).NotEmpty();
    }
  }
}
