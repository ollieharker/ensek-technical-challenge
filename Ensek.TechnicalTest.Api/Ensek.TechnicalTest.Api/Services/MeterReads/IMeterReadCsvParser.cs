namespace Ensek.TechnicalTest.Api.Services.MeterReads
{
	public interface IMeterReadCsvParser
	{
		MeterReadParsingResult ParseCsvToMeterReadings(Stream stream);
	}
}