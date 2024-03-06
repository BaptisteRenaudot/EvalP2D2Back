using EvalP2D2.DTO;
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
    
    /// <summary>
    /// Get alls events from the database asynchronously.
    /// </summary>
    /// <returns> The list of events.</returns>
    public Task<IEnumerable<EventEntity>> GetEvents();
    
    /// <summary>
    /// Deletes an event from the database asynchronously.
    /// </summary>
    /// <param name="id">The ID of the event to delete.</param>
    /// <returns>true if the event is deleted successfully; otherwise, false.</returns>
    public Task<bool> DeleteAsync(Guid id);
    
    /// <summary>
    /// Update an event in the database asynchronously.
    /// </summary>
    /// <param name="entity"> The event to update.</param>
    /// <param name="id">The ID of the event to update.</param>
    /// <returns>true if the event is updated successfully; otherwise, false.</returns>
    public Task<EventEntity> UpdateAsync(Guid id, EventDTO entity);

}