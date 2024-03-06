using Azure.Core;
using EvalP2D2.DAL;
using EvalP2D2.DTO;
using EvalP2D2.Entity;
using EvalP2D2.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EvalP2D2.Repository;

public class EventRepository: IEventRepository
{
    private readonly EvalDbContext _context;
    
    public EventRepository(IDbContextFactory<EvalDbContext> contextFactory)
    {
        this._context = contextFactory.CreateDbContext();
    }

    public async Task AddAsync(EventEntity entity)
    {
        this._context.eventEntity.Add(entity);
        await this._context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<EventEntity>> GetEvents()
    {
        return await this._context.eventEntity.ToListAsync();
    }
    
    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await this._context.eventEntity.FindAsync(id);
        if (entity == null)
        {
            return false;
        }
        this._context.eventEntity.Remove(entity);
        await this._context.SaveChangesAsync();
        return true;
    }
    
    public async Task<EventEntity> UpdateAsync(Guid id, EventDTO entity)
    {
        var data = await this._context.eventEntity.FindAsync(id);

        if (data == null)
        {
            throw new Exception("Event not found");
        }
        else
        {
            data.Title = entity.Title;
            data.Description = entity.Description;
            data.DateTime = entity.DateTime;
            data.Location = entity.Location;
            await this._context.SaveChangesAsync();
            return data;
        }
    }
}