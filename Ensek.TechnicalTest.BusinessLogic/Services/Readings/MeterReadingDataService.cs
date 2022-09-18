using Ensek.TechnicalTest.Data.Repositories;
using Ensek.TechnicalTest.Db.Models;
using Microsoft.EntityFrameworkCore;

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
			var uniqueReadingsWithAccounts = this.GetUniqueReadingsWithExistingAccounts(meterReadings, addMeterReadingResult);

			foreach (var reading in uniqueReadingsWithAccounts)
			{
				try
				{
					this.meterReadingRepository.Add(reading);
					addMeterReadingResult.AddedReadingCount++;
				}
				catch(Exception)
				{
					addMeterReadingResult.RejectedReadingCount++;
				}
			}

			return addMeterReadingResult;
		}

		private IEnumerable<MeterReading> GetUniqueReadingsWithExistingAccounts(IEnumerable<MeterReading> meterReadings, AddMeterReadingResult addMeterReadingResult)
		{
			var accounts = this.accountRepository.GetAll()
				.Include(m => m.Readings);

			var readingsWithAccounts = meterReadings.Join(accounts, reading => reading.AccountId, a => a.Id, (reading, account) => (reading, account));
			var readingsExcludingDuplicateValues = readingsWithAccounts
				.Where(m => !m.account.Readings.Any(reading => reading.Value == m.reading.Value))
				.Select(m => m.reading)
				.DistinctBy(m =>  new{ m.AccountId, m.Value})
				.ToList();

			addMeterReadingResult.RejectedReadingCount += meterReadings.Count() - readingsExcludingDuplicateValues.Count();

			return readingsExcludingDuplicateValues;
		}
	}
}
