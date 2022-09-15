using Ensek.TechnicalTest.Data.Repositories;
using Ensek.TechnicalTest.Db.Models;

namespace Ensek.TechnicalTest.Data.Services.Readings
{
	public class MeterReadingService : IMeterReadingService
	{
		private readonly IRepository<MeterReading> meterReadingRepository;

		public MeterReadingService(IRepository<MeterReading> meterReadingRepository)
		{
			this.meterReadingRepository = meterReadingRepository;
		}

		public AddMeterReadingResult AddMeterReadings(IEnumerable<MeterReading> meterReadings)
		{
			var addMeterReadingResult = new AddMeterReadingResult();

			foreach (var reading in meterReadings)
			{
				try
				{
					this.ValidateAndAdd(reading);
					addMeterReadingResult.AddedReadingCount++;
				}
				catch (Exception ex)
				{
					addMeterReadingResult.RejectedReadingCount++;
				}
			}

			return addMeterReadingResult;
		}

		private void ValidateAndAdd(MeterReading meterReading)
		{
			this.meterReadingRepository.Add(meterReading);
		}
	}
}
