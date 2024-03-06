using EvalP2D2.Entity;

namespace EvalP2D2.Service.Contracts;

public interface IEventService
{
    /// <summary>
    /// Adds a new event to the database.
    /// </summary>
    /// <param name="entity"> The event to add.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> AddAsync(EventEntity entity);
    
    /// <summary>
    /// Get alls events from the database.
    /// </summary>
    /// <returns> The list of events.</returns>
    public Task<IEnumerable<EventEntity>> GetEvents();
}