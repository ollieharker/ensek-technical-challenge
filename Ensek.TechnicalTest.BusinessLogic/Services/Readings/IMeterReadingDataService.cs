using Ensek.TechnicalTest.Db.Models;

namespace Ensek.TechnicalTest.Data.Services.Readings
{
	public interface IMeterReadingDataService
	{
		AddMeterReadingResult AddMeterReadings(IEnumerable<MeterReading> meterReadings);
	}
}