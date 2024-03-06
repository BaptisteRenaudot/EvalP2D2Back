using EvalP2D2.Entity;

namespace EvalP2D2.Repository.Contracts;

public interface IEventRepository
{
    /// <summary>
    /// Adds a new event to the database asynchronously.
    /// </summary>
    /// <param name="entity"> The event to add.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task AddAsync(EventEntity entity);
}