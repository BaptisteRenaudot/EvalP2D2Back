using System.Collections.Generic;
using System.Net;
using EvalP2D2.Service.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;


namespace EvalP2D2.API.Controller.eventController;

public class EventPostFunction
{
    private readonly ILogger _logger;
    private readonly IEventService _eventService;


    public EventPostFunction(ILoggerFactory loggerFactory, IEventService eventService)
    {
        _logger = loggerFactory.CreateLogger<EventPostFunction>();
        _eventService = eventService;
    }


    [Function("EventAddFunction")]
    public async Task<HttpResponseData> Add([HttpTrigger(AuthorizationLevel.Function, "post", Route = "events")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var response = req.CreateResponse(HttpStatusCode.Created);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");

        try
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var newEvent = JsonConvert.DeserializeObject<Entity.EventEntity>(requestBody);

            if (newEvent != null)
            {
                await this._eventService.AddAsync(newEvent);
            }
        }
        catch (JsonException _)
        {
            await response.WriteStringAsync("Invalid JSON format.");
            response.StatusCode = HttpStatusCode.BadRequest;
        }
        catch (DbUpdateException dbEx)
        {
            await response.WriteStringAsync("An error occurred while updating the database.");
            response.StatusCode = HttpStatusCode.InternalServerError;
        }
        catch (Exception e)
        {
            await response.WriteStringAsync(e.Message);
            response.StatusCode = HttpStatusCode.InternalServerError;
        }

        return response;
    }
}