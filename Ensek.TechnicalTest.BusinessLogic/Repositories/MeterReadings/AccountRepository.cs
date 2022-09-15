using Ensek.TechnicalTest.Db.Context;
using Ensek.TechnicalTest.Db.Models;

namespace Ensek.TechnicalTest.Data.Repositories.MeterReadings
{
	public class AccountRepository : IRepository<Account>
	{
		private readonly EnsekDbContext ensekDbContext;

		public AccountRepository(EnsekDbContext ensekDbContext)
		{
			this.ensekDbContext = ensekDbContext;
		}

		public void Add(Account entity)
		{
			this.ensekDbContext.Add(entity);
			this.ensekDbContext.SaveChanges();
		}

		public IQueryable<Account> GetAll() => this.ensekDbContext.Accounts.AsQueryable();
	}
}
