using Ensek.TechnicalTest.Db.Models;

namespace Ensek.TechnicalTest.Api.Services.MeterReads
{
	public record MeterReadParsingResult
	{
		public MeterReadParsingResult(IEnumerable<MeterReading> meterReadingsParsed, int failedCount)
		{
			this.NewMeterReadings = meterReadingsParsed;
			this.ParseFailedCount = failedCount;
		}

		public int ParseFailedCount { get; init; }

		public IEnumerable<MeterReading> NewMeterReadings { get; init; }
	}
}
