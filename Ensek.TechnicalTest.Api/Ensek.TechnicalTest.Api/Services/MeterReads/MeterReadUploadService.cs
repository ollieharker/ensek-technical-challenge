using Ensek.TechnicalTest.Api.Dto;
using Ensek.TechnicalTest.Data.Services.Readings;

namespace Ensek.TechnicalTest.Api.Services.MeterReads
{
	public class MeterReadCsvUploadService : IMeterReadCsvUploadService
	{
		private readonly IMeterReadCsvParser meterReadCsvParser;
		private readonly IMeterReadingService meterReadingService;

		public MeterReadCsvUploadService(IMeterReadCsvParser meterReadCsvParser, IMeterReadingService meterReadingService)
		{
			this.meterReadCsvParser = meterReadCsvParser;
			this.meterReadingService = meterReadingService;
		}

		public MeterReadingUploadResult UploadMeterReadsFromStream(Stream stream)
		{
			var parsingResult = this.meterReadCsvParser.ParseCsvToMeterReadings(stream);
			var updateResult = this.meterReadingService.AddMeterReadings(parsingResult.NewMeterReadings);

			return new MeterReadingUploadResult
			{
				UploadsSuccessful = updateResult.AddedReadingCount,
				UploadsFailedToParse = parsingResult.ParseFailedCount,
				UploadsFailedToSave = updateResult.RejectedReadingCount
			};
		}
	}
}
