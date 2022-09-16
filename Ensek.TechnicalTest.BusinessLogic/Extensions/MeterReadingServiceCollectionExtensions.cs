using Ensek.TechnicalTest.BusinessLogic.Validation;
using Ensek.TechnicalTest.Data.Repositories;
using Ensek.TechnicalTest.Data.Repositories.MeterReadings;
using Ensek.TechnicalTest.Data.Services.Readings;
using Ensek.TechnicalTest.Db.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Ensek.TechnicalTest.Data.Extensions
{
	public static class MeterReadingServiceCollectionExtensions
	{
		public static IServiceCollection AddMeterReadingDataServices(this IServiceCollection services)
		{
			return services
				.AddScoped<IRepository<MeterReading>, MeterReadingRepository>()
				.AddScoped<IRepository<Account>, AccountRepository>()
				.AddScoped<MeterReadingValidator>()
				.AddScoped<IMeterReadingDataService, MeterReadingDataService>();
		}
	}
}
