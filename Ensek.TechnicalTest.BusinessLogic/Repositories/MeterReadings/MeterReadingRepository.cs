using Ensek.TechnicalTest.BusinessLogic.Validation;
using Ensek.TechnicalTest.Db.Context;
using Ensek.TechnicalTest.Db.Models;
using FluentValidation;

namespace Ensek.TechnicalTest.Data.Repositories.MeterReadings
{
	public class MeterReadingRepository : IRepository<MeterReading>
	{
		private readonly EnsekDbContext ensekDbContext;
		private readonly IValidator<MeterReading> validator;

		public MeterReadingRepository(EnsekDbContext ensekDbContext, MeterReadingValidator validator)
		{
			this.ensekDbContext = ensekDbContext;
			this.validator = validator;
		}

		public void Add(MeterReading meterReading)
		{
			this.validator.ValidateAndThrow(meterReading);

			this.ensekDbContext.Add(meterReading);
			this.ensekDbContext.SaveChanges();
		}

		public IQueryable<MeterReading> GetAll() => this.ensekDbContext.MeterReadings.AsQueryable();
	}
}
