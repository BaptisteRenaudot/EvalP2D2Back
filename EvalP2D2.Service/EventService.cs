using EvalP2D2.DTO;
using EvalP2D2.Entity;
using EvalP2D2.Repository.Contracts;
using EvalP2D2.Service.Contracts;

namespace EvalP2D2.Service;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    /// <summary>
    /// Adds a new event to the database.
    /// </summary>
    /// <param name="entity">The event to add.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> AddAsync(EventEntity entity)
    {
        await this._eventRepository.AddAsync(entity);
        return true;
    }
    
    /// <summary>
    /// Get alls events from the database.
    /// </summary>
    /// <returns>The list of events.</returns>
    public async Task<IEnumerable<EventEntity>> GetEvents()
    {
        return await this._eventRepository.GetEvents();
    }
    
    /// <summary>
    /// Deletes an event from the database.
    /// </summary>
    /// <param name="id">The ID of the event to delete.</param>
    /// <returns>true if the event is deleted successfully; otherwise, false.</returns>
    public async Task<bool> DeleteAsync(Guid id)
    {
        return await this._eventRepository.DeleteAsync(id);
    }

    /// <summary>
    /// Update an event in the database.
    /// </summary>
    /// <param name="entity">The event to update.</param>
    /// <param name="applicationId">The ID of the event to update.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<EventEntity> UpdateAsync(Guid applicationId, EventDTO entity)
    {
        return await this._eventRepository.UpdateAsync(applicationId, entity);
    }
}