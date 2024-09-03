namespace PayCard.Domain.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(long id);

        Task<IQueryable<T>> GetAllAsync(long Id);

        Task<T> CreateAsync(long Id);

        Task<T> UpdateAsync(long Id);

        Task<T> DeleteAsync(long Id);

        Task<IQueryable<T>> Query();
    }
}

