using CsvHelper.Configuration;
using CsvHelper;
using Ensek.TechnicalTest.BusinessLogic.Dto.MeterReading;
using System.Globalization;
using Ensek.TechnicalTest.Api.Extensions;

namespace Ensek.TechnicalTest.Api.Services.MeterReads
{
	public class MeterReadCsvParser : IMeterReadCsvParser
	{
		public MeterReadParsingResult ParseCsvToMeterReadings(Stream stream)
		{
			int parseFailedCount = default;
			var csvConfiguration = new CsvConfiguration(CultureInfo.GetCultureInfo("en-GB"))
			{
				BadDataFound = (_) => { parseFailedCount++; },
				ReadingExceptionOccurred = (_) => { parseFailedCount++; return false; },
			};

			var readingDtos = this.ParseWithConfiguration(stream, csvConfiguration);

			return new MeterReadParsingResult(readingDtos.Select(m => m.ToMeterReading()), parseFailedCount);
		}

		private IEnumerable<NewMeterReadingDto> ParseWithConfiguration(Stream stream, IReaderConfiguration config)
		{
			using (var reader = new StreamReader(stream))
			using (var csvReader = new CsvReader(reader, config))
			{
				csvReader.Context.RegisterClassMap<MeterReadingCsvMap>();

				return csvReader.GetRecords<NewMeterReadingDto>().ToList();
			}
		}
	}
}
