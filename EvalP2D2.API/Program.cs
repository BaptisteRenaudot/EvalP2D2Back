using EvalP2D2.DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddDbContext<EvalP2D2.DAL.EvalDbContext>(options =>
        {
            options.UseSqlServer("Server=localhost;Database=Eval;User Id=sa;Password=MyPass@word;TrustServerCertificate=True");
        });
    })
    .Build();

host.Run();