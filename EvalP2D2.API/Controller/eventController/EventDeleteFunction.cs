using System.Collections.Generic;
using System.Net;
using EvalP2D2.Service.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EvalP2D2.API.Controller.eventController;

public class EventDeleteFunction
{
    private readonly ILogger _logger;
    private readonly IEventService _eventService;


    public EventDeleteFunction(ILoggerFactory loggerFactory, IEventService eventService)
    {
        _logger = loggerFactory.CreateLogger<EventPostFunction>();
        _eventService = eventService;
    }

    [Function("EventDeleteFunction")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "events/{id}")] HttpRequestData req, Guid id,
        FunctionContext executionContext)
    {
        var response = req.CreateResponse(HttpStatusCode.NoContent);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");

        try
        {
            await this._eventService.DeleteAsync(id);
        }
        catch (DbUpdateException e)
        {
            await response.WriteStringAsync(JsonConvert.SerializeObject(new { errorMessage = e.Message }));
            response.StatusCode = HttpStatusCode.InternalServerError;
        }
        catch (Exception e)
        {
            await response.WriteStringAsync(JsonConvert.SerializeObject(new { errorMessage = e.Message }));
            response.StatusCode = HttpStatusCode.InternalServerError;
        }

        return response;
    }
}