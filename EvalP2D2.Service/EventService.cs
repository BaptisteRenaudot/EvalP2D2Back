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

    public async Task<bool> AddAsync(EventEntity entity)
    {
        await this._eventRepository.AddAsync(entity);
        return true;
    }
    
    public async Task<IEnumerable<EventEntity>> GetEvents()
    {
        return await this._eventRepository.GetEvents();
    }
}