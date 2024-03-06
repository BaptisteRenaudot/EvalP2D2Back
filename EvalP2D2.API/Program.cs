using EvalP2D2.DAL;
using EvalP2D2.Repository;
using EvalP2D2.Repository.Contracts;
using EvalP2D2.Service;
using EvalP2D2.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddDbContextFactory<EvalDbContext>(options =>
        {
            options.UseSqlServer("Server=localhost;Database=Eval;User Id=sa;Password=MyPass@word;TrustServerCertificate=True");
        });
        
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IEventRepository, EventRepository>();
    })
    .Build();

host.Run();