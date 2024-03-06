using System.Collections.Generic;
using System.Net;
using EvalP2D2.DTO;
using EvalP2D2.Service.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EvalP2D2.API.Controller.eventController;

public class EventPutFunction
{
    private readonly ILogger _logger;
    private readonly IEventService _eventService;


    public EventPutFunction(ILoggerFactory loggerFactory, IEventService eventService)
    {
        _logger = loggerFactory.CreateLogger<EventPostFunction>();
        _eventService = eventService;
    }

    [Function("EventPutFunction")]
    public async Task<HttpResponseData> Put([HttpTrigger(AuthorizationLevel.Function, "put", Route = "events/{id}")] HttpRequestData req, Guid id,
        FunctionContext executionContext)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");

        try
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var app = JsonConvert.DeserializeObject<EventDTO>(requestBody);
            if (app != null)
            {
                var updatedApp = await this._eventService.UpdateAsync(id, app);
                await response.WriteStringAsync(JsonConvert.SerializeObject(updatedApp));
            }
            else
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                await response.WriteStringAsync("Invalid JSON format.");
            }

            return response;
        }
        catch (JsonException jsonException)
        {
            response.StatusCode = HttpStatusCode.BadRequest;
            await response.WriteStringAsync("Invalid JSON format: " + jsonException.Message);

            return response;
        }
        catch (Exception e)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            await response.WriteStringAsync($"Error: {e.Message}");
            return response;
        }
    }
}