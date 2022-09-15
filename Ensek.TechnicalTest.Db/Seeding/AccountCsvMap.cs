
using CsvHelper.Configuration;
using Ensek.TechnicalTest.Db.Models;

namespace Ensek.TechnicalTest.Db.Seeding
{
	public class AccountCsvMap : ClassMap<Account>
	{
		public AccountCsvMap()
		{
			Map(m => m.Id).Name("AccountId");
			Map(m => m.FirstName).Name("FirstName");
			Map(m => m.LastName).Name("LastName");
		}
	}
}
