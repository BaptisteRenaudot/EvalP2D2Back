using EvalP2D2.DTO;
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
    
    /// <summary>
    /// Deletes an event from the database.
    /// </summary>
    /// <param name="id">The ID of the event to delete.</param>
    /// <returns>true if the event is deleted successfully; otherwise, false.</returns>
    public Task<bool> DeleteAsync(Guid id);
    
    /// <summary>
    /// Update an event in the database.
    /// </summary>
    /// <param name="entity"> The event to update.</param>
    /// <param name="id">The ID of the event to update.</param>
    /// <returns>true if the event is updated successfully; otherwise, false.</returns>
    public Task<EventEntity> UpdateAsync(Guid id, EventDTO entity);

}