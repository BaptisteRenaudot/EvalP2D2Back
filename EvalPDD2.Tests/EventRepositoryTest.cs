// using EvalP2D2.Entity;
// using EvalP2D2.Repository;
// using EvalP2D2.Repository.Contracts;
// using EvalP2D2.Service;
// using EvalP2D2.Service.Contracts;
// using Microsoft.Extensions.DependencyInjection;
//
// namespace EvalPDD2.Tests;
//
// public class Tests
// {
//     [SetUp]
//     public void Setup()
//     {
//         var services = new ServiceCollection();
//         
//         services.AddScoped<IEventService, EventService>();
//         services.AddScoped<IEventRepository, EventRepository>();
//     }
//
//     [Test]
//     public void TryAddEvent()
//     {
//         var eventService = new EventService(new EventRepository());
//         var eventEntity = new EventEntity
//         {
//             Title = "Test",
//             Description = "Test",
//             DateTime = DateTime.Now,
//             Location = "Test"
//         };
//         var state = eventService.AddAsync(eventEntity);
//         Assert.IsTrue(state.Result);
//     }
// }