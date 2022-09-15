using CsvHelper;
using Ensek.TechnicalTest.Db.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Ensek.TechnicalTest.Db.Seeding
{
	internal static class AccountEntitySeeder
	{
		/// <summary>
		/// Seed the data for the <see cref="Account"/> entity.
		/// </summary>
		/// <param name="modelBuilder">The model builder to seed the data with.</param>
		public static void SeedData(ModelBuilder modelBuilder)
		{
			using(var reader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Seeding/Data/Test_Accounts.csv"))
			using(var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csvReader.Context.RegisterClassMap<AccountCsvMap>();

				var accounts = csvReader.GetRecords<Account>();
				modelBuilder.Entity<Account>()
					.HasData(accounts);
			}
		}
	}
}
