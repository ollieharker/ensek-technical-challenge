using Ensek.TechnicalTest.Db.Models;
using System.Collections;
using Xunit;

namespace Ensek.TechnicalTest.Data.Tests.Services
{
	public class MeterReadingDataServiceTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			var accounts = new List<Account>()
			{
				new Account(){Id = 1, FirstName = "Account", LastName = "One" },
				new Account(){Id = 2, FirstName = "Account", LastName = "One" },
				new Account(){Id = 3, FirstName = "Account", LastName = "One" }
			};

			var meterReadingsWithAccounts = new List<MeterReading>()
			{
				new MeterReading(){AccountId = accounts[0].Id, Value = 123},
				new MeterReading(){AccountId = accounts[1].Id, Value = 42},
				new MeterReading(){AccountId = accounts[0].Id, Value = 32},
				new MeterReading(){AccountId = accounts[2].Id, Value = 1}
			};

			var meterReadingsWithoutAccounts = new List<MeterReading>()
			{
				new MeterReading(){ AccountId = 10, Value = 53},
				new MeterReading(){ AccountId = 11, Value = 53},
				new MeterReading(){ AccountId = 12, Value = 53},
				new MeterReading(){ AccountId = 13, Value = 53},
				new MeterReading(){ AccountId = 14, Value = 53},
			};

			yield return new object[] { accounts, meterReadingsWithAccounts, meterReadingsWithoutAccounts };
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
