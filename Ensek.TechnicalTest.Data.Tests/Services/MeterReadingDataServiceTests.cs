using Ensek.TechnicalTest.Data.Repositories;
using Ensek.TechnicalTest.Data.Services.Readings;
using Ensek.TechnicalTest.Db.Models;
using Moq;
using Xunit;

namespace Ensek.TechnicalTest.Data.Tests.Services
{
	public class MeterReadingDataServiceTests
	{
		private readonly Mock<IRepository<MeterReading>> mockMeterReadingRepository;
		private readonly Mock<IRepository<Account>> mockAccountRepository;
		private readonly MeterReadingDataService sut;

		public MeterReadingDataServiceTests()
		{
			this.mockMeterReadingRepository = new Mock<IRepository<MeterReading>>();
			this.mockAccountRepository = new Mock<IRepository<Account>>();
			this.sut = new MeterReadingDataService(this.mockMeterReadingRepository.Object, this.mockAccountRepository.Object);
		}

		[Theory]
		[ClassData(typeof(MeterReadingDataServiceTestData))]
		public void AddMeterReadingsGivenMeterReadingsReadingsWithNoAccountsIgnored(IEnumerable<Account> accountsInDb, 
			IEnumerable<MeterReading> readingsWithAccounts, 
			IEnumerable<MeterReading> readingsWithoutAccounts )
		{
			var readings = this.BuildReadingsAndAccountsRepo(accountsInDb, readingsWithAccounts, readingsWithoutAccounts);

			this.sut.AddMeterReadings(readings);

			foreach (var reading in readingsWithAccounts)
			{
				this.mockMeterReadingRepository.Verify(repo => repo.Add(reading), Times.Once);
			}

			foreach (var reading in readingsWithoutAccounts)
			{
				this.mockMeterReadingRepository.Verify(repo => repo.Add(reading), Times.Never);
			}
		}

		[Theory]
		[ClassData(typeof(MeterReadingDataServiceTestData))]
		public void AddMeterReadingsGivenMeterReadingsReadingsWithAccountsAddedToResultCount(
			IEnumerable<Account> accountsInDb,
			IEnumerable<MeterReading> readingsWithAccounts,
			IEnumerable<MeterReading> readingsWithoutAccounts)
		{
			var expectedCount = readingsWithAccounts.Count();
			var readings = this.BuildReadingsAndAccountsRepo(accountsInDb, readingsWithAccounts, readingsWithoutAccounts);

			var result = this.sut.AddMeterReadings(readings);

			Assert.Equal(expectedCount, result.AddedReadingCount);
		}

		[Theory]
		[ClassData(typeof(MeterReadingDataServiceTestData))]
		public void AddMeterReadingsGivenMeterReadingsReadingsWithNoAccountsAddedToResultCount(
			IEnumerable<Account> accountsInDb,
			IEnumerable<MeterReading> readingsWithAccounts,
			IEnumerable<MeterReading> readingsWithoutAccounts)
		{
			var expectedCount = readingsWithoutAccounts.Count();
			var readings = this.BuildReadingsAndAccountsRepo(accountsInDb, readingsWithAccounts, readingsWithoutAccounts);

			var result = this.sut.AddMeterReadings(readings);

			Assert.Equal(expectedCount, result.RejectedReadingCount);
		}

		[Theory]
		[ClassData(typeof(MeterReadingDataServiceTestData))]
		public void AddMeterReadingsGivenExceptionThrownUponAddAddedToRejectedCount(
				IEnumerable<Account> accountsInDb,
				IEnumerable<MeterReading> readingsWithAccounts,
				IEnumerable<MeterReading> readingsWithoutAccounts)
		{
			this.mockMeterReadingRepository.Setup(repo => repo.Add(readingsWithAccounts.First())).Throws(() => new Exception("Error adding to database."));

			var expectedRejectedCount = readingsWithoutAccounts.Count() + 1;

			var readings = this.BuildReadingsAndAccountsRepo(accountsInDb, readingsWithAccounts, readingsWithoutAccounts);

			var result = this.sut.AddMeterReadings(readings);

			Assert.Equal(expectedRejectedCount, result.RejectedReadingCount);
		}

		private List<MeterReading> BuildReadingsAndAccountsRepo(
			IEnumerable<Account> accountsInDb, 
			IEnumerable<MeterReading> readingsWithAccounts, 
			IEnumerable<MeterReading> readingsWithoutAccounts)
		{
			this.mockAccountRepository.Setup(repo => repo.GetAll()).Returns(accountsInDb.AsQueryable);

			var readings = new List<MeterReading>();
			readings.AddRange(readingsWithAccounts);
			readings.AddRange(readingsWithoutAccounts);
			return readings;
		}

	}
}
