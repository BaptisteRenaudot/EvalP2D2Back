using System.Collections.Generic;
using System.Net;
using EvalP2D2.Service.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EvalP2D2.API.Controller.eventController;

public class EventGetFunction
{
    private readonly ILogger _logger;
    private readonly IEventService _eventService;


    public EventGetFunction(ILoggerFactory loggerFactory, IEventService eventService)
    {
        _logger = loggerFactory.CreateLogger<EventPostFunction>();
        _eventService = eventService;
    }

    [Function("EventGetFunction")]
    public async Task<HttpResponseData> Get(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "events")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");

        try
        {
            var events = await this._eventService.GetEvents();
            var eventsJson = JsonConvert.SerializeObject(events);
            await response.WriteStringAsync(eventsJson);
        }
        catch (Exception e)
        {
            await response.WriteStringAsync(e.Message);
            response.StatusCode = HttpStatusCode.InternalServerError;
        }
        
        return response;
    }
}