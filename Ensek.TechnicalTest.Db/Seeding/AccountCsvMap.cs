
using CsvHelper.Configuration;
using Ensek.TechnicalTest.Db.Models;

namespace Ensek.TechnicalTest.Db.Seeding
{
	public class AccountCsvMap : ClassMap<Account>
	{
		public AccountCsvMap()
		{
			this.Map(model => model.Id).Name("AccountId");
			this.Map(model => model.FirstName).Name("FirstName");
			this.Map(model => model.LastName).Name("LastName");
		}
	}
}
