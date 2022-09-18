using Ensek.TechnicalTest.Api.Services.MeterReads;
using Ensek.TechnicalTest.Data.Extensions;

namespace Ensek.TechnicalTest.Api.Extensions
{
	public static class MeterReadParsingServiceCollectionExtensions
	{
		public static IServiceCollection AddMeterReadCsvParsingServices(this IServiceCollection services)
		{
			return services
				.AddScoped<IMeterReadCsvUploadService, MeterReadCsvUploadService>()
				.AddScoped<IMeterReadCsvParser, CsvHelperMeterReadCsvParser>()
				.AddMeterReadingDataServices();
		}
	}
}
