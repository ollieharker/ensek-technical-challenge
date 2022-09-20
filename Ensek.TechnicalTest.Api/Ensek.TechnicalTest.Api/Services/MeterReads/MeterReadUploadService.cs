using Ensek.TechnicalTest.Api.Dto;
using Ensek.TechnicalTest.Api.Exceptions;
using Ensek.TechnicalTest.Data.Services.Readings;

namespace Ensek.TechnicalTest.Api.Services.MeterReads
{
	public class MeterReadCsvUploadService : IMeterReadCsvUploadService
	{
		private readonly IMeterReadCsvParser meterReadCsvParser;
		private readonly IMeterReadingDataService meterReadingService;

		public MeterReadCsvUploadService(IMeterReadCsvParser meterReadCsvParser, IMeterReadingDataService meterReadingService)
		{
			this.meterReadCsvParser = meterReadCsvParser;
			this.meterReadingService = meterReadingService;
		}

		/// <summary>
		/// Upload Meter Readings via the provided .CSV stream.
		/// </summary>
		/// <param name="stream">Stream containing the CSV to upload.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">Thrown if the stream provided is null.</exception>
		/// <exception cref="MeterReadUploadException">Thrown if issues are encountered parsing the file. See inner exception for more details.</exception>
		public MeterReadingUploadResult UploadMeterReadsFromStream(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException(nameof(stream));
			}

			try
			{
				var result = this.ParseAndUpload(stream);
				return result;
			}
			catch (MeterReadParsingException ex)
			{
				throw new MeterReadUploadException("An error occured parsing the provided CSV input.", ex);
			}
			catch (Exception ex)
			{
				throw new MeterReadUploadException("An unexpected error occured uploading meter reads.", ex);
			}
		}

		private MeterReadingUploadResult ParseAndUpload(Stream stream)
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
