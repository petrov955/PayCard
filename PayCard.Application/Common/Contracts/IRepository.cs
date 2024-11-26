using PayCard.Domain.Common.Contracts;

namespace PayCard.Application.Common.Contracts
{
    public interface IRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task SaveAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
