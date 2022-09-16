using Ensek.TechnicalTest.Data.Repositories;
using Ensek.TechnicalTest.Db.Models;

namespace Ensek.TechnicalTest.Data.Services.Readings
{
	public class MeterReadingDataService : IMeterReadingDataService
	{
		private readonly IRepository<MeterReading> meterReadingRepository;
		private readonly IRepository<Account> accountRepository;

		public MeterReadingDataService(IRepository<MeterReading> meterReadingRepository, IRepository<Account> accountRepository)
		{
			this.meterReadingRepository = meterReadingRepository;
			this.accountRepository = accountRepository;
		}

		public AddMeterReadingResult AddMeterReadings(IEnumerable<MeterReading> meterReadings)
		{
			var addMeterReadingResult = new AddMeterReadingResult();
			var readingsWithAccounts = this.GetReadingsWithExistingAccounts(meterReadings, addMeterReadingResult);

			foreach (var reading in readingsWithAccounts)
			{
				try
				{
					this.meterReadingRepository.Add(reading);
					addMeterReadingResult.AddedReadingCount++;
				}
				catch
				{
					addMeterReadingResult.RejectedReadingCount++;
				}
			}

			return addMeterReadingResult;
		}

		private IEnumerable<MeterReading> GetReadingsWithExistingAccounts(IEnumerable<MeterReading> meterReadings, AddMeterReadingResult addMeterReadingResult)
		{
			var accounts = this.accountRepository.GetAll();
			var readingsWithAccounts = meterReadings
				.Join(accounts, reading => reading.AccountId, a => a.Id, (reading, account) => reading);

			addMeterReadingResult.RejectedReadingCount += meterReadings.Count() - readingsWithAccounts.Count();

			return readingsWithAccounts;
		}
	}
}
