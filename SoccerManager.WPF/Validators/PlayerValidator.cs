using System;
using FluentValidation;
using SoccerManager.Client.Helpers;
using SoccerManager.Client.Models;

namespace SoccerManager.Client.Validators
{
  public class PlayerValidator : AbstractValidator<Player>
  {
    public PlayerValidator()
    {
      RuleFor(p => p.Name).Cascade(CascadeMode.Continue).NotEmpty().Must(n => ValidationHelper.DoesNotContainBannedSymbols(n));
      RuleFor(p => p.Snils).NotEmpty().Length(14);
      RuleFor(p => p.BirthDate).LessThan(DateTime.Today);
    }
  }
}
