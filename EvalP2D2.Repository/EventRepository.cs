using Azure.Core;
using EvalP2D2.DAL;
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
}