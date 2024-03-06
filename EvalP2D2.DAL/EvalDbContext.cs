using EvalP2D2.Entity;
using Microsoft.EntityFrameworkCore;

namespace EvalP2D2.DAL;

public class EvalDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public EvalDbContext(DbContextOptions<EvalDbContext> options)
        : base(options)
    {
    }

    public DbSet<Class1> Class1 { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Class1>(
            class1Entity =>
            {
                class1Entity.ToTable("Class1");
                class1Entity.HasKey(e => e.Id);
                class1Entity.Property(e => e.Id).HasDefaultValueSql("NEWID()").HasColumnName("Id");
                class1Entity.Property(e => e.MyProperty).IsRequired().HasColumnName("MyProperty");
                class1Entity.Property(e => e.MyProperty2).IsRequired().HasMaxLength(50).HasColumnName("MyProperty2");
            });
    }
}