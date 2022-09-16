using CsvHelper.Configuration;
using CsvHelper;
using Ensek.TechnicalTest.BusinessLogic.Dto.MeterReading;
using System.Globalization;
using Ensek.TechnicalTest.Api.Extensions;
using Ensek.TechnicalTest.Api.Exceptions;

namespace Ensek.TechnicalTest.Api.Services.MeterReads
{
	public class MeterReadCsvParser : IMeterReadCsvParser
	{
		public MeterReadParsingResult ParseCsvToMeterReadings(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException(nameof(stream));
			}

			return this.Parse(stream);
		}

		private MeterReadParsingResult Parse(Stream stream)
		{
			int parseFailedCount = default;
			var csvConfiguration = new CsvConfiguration(CultureInfo.GetCultureInfo("en-GB"))
			{
				// When invalid CSV records are found, continue and increment the parsed failure count.
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

				try
				{
					return csvReader.GetRecords<NewMeterReadingDto>().ToList();
				}
				catch (CsvHelperException ex)
				{
					throw new MeterReadParsingException("An error occured parsing CSV records.", ex);
				}
			}
		}
	}
}
