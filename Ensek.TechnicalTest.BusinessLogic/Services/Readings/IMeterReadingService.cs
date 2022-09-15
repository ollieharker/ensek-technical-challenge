using Ensek.TechnicalTest.Db.Models;

namespace Ensek.TechnicalTest.Data.Services.Readings
{
	public interface IMeterReadingService
	{
		AddMeterReadingResult AddMeterReadings(IEnumerable<MeterReading> meterReadings);
	}
}