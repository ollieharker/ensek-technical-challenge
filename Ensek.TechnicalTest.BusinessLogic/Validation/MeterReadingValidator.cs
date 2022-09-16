using Ensek.TechnicalTest.Db.Models;
using FluentValidation;

namespace Ensek.TechnicalTest.BusinessLogic.Validation
{
    public class MeterReadingValidator : AbstractValidator<MeterReading>
    {
        const uint longestReadingValue = 99999;
        public MeterReadingValidator()
        {
            RuleFor(model => model.Value).LessThanOrEqualTo(longestReadingValue);
        }
    }
}
