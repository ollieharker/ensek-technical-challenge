
namespace Ensek.TechnicalTest.Data.Repositories
{
	public interface IRepository<T>
	{
		/// <summary>
		/// Add the provided entity to the data storage mechanism.
		/// </summary>
		/// <param name="entity">The entity to add.</param>
		void Add(T entity);

		/// <summary>
		/// Retrieve an <see cref="IQueryable{T}"/> of the entities within the data storage mechanism.
		/// </summary>
		/// <returns>Returned entities from the data storage mechanism.</returns>
		IQueryable<T> GetAll();
	}
}
