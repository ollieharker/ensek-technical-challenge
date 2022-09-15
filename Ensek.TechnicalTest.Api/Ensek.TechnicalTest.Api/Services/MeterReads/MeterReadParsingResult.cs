using Ensek.TechnicalTest.BusinessLogic.Dto.MeterReading;
using Ensek.TechnicalTest.Db.Models;

namespace Ensek.TechnicalTest.Api.Services.MeterReads
{
	public record MeterReadParsingResult
	{
		public MeterReadParsingResult(IEnumerable<MeterReading> meterReadingsParsed, int failedCount)
		{
			this.NewMeterReadings = meterReadingsParsed;
			this.ParseFailedCount = failedCount;
			this.ParseSucceededCount = meterReadingsParsed.Count();
		}

		public int TotalRows => this.ParseSucceededCount + this.ParseFailedCount;

		public int ParseSucceededCount { get; init; }

		public int ParseFailedCount { get; init; }

		public IEnumerable<MeterReading> NewMeterReadings { get; init; }
	}
}
