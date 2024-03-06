using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EvalP2D2.DAL;

public class EvalDbContextFactory : IDesignTimeDbContextFactory<EvalDbContext>
{
    public EvalDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EvalDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=Eval;User Id=sa;Password=MyPass@word;TrustServerCertificate=True");

        return new EvalDbContext(optionsBuilder.Options);
    }
}