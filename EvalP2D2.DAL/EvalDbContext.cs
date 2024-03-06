using EvalP2D2.Entity;
using Microsoft.EntityFrameworkCore;

namespace EvalP2D2.DAL;

public class EvalDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public EvalDbContext(DbContextOptions<EvalDbContext> options)
        : base(options)
    {
    }
    
        public DbSet<EventEntity> eventEntity { get; set; }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<EventEntity>(
            eventEntity =>
            {
                eventEntity.ToTable("Event");
                eventEntity.HasKey(e => e.Id);
                eventEntity.Property(e => e.Id).HasDefaultValueSql("NEWID()").HasColumnName("Id");
                eventEntity.Property(e => e.Title).IsRequired().HasMaxLength(50).HasColumnName("Title");
                eventEntity.Property(e => e.Description).IsRequired().HasMaxLength(50).HasColumnName("Description");
                eventEntity.Property(e => e.DateTime).IsRequired().HasColumnName("DateTime");
                eventEntity.Property(e => e.Location).IsRequired().HasMaxLength(50).HasColumnName("Location");
            });
    }
}