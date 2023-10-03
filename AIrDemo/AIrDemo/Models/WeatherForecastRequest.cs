namespace AIrDemo.Models
{
    public class WeatherForecastRequest
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }


public static class WeatherForecastRequestEndpoints
{
	public static void MapWeatherForecastRequestEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/WeatherForecastRequest", () =>
        {
            return new [] { new WeatherForecastRequest() };
        })
        .WithName("GetAllWeatherForecastRequests")
        .Produces<WeatherForecastRequest[]>(StatusCodes.Status200OK);

        routes.MapGet("/api/WeatherForecastRequest/{id}", (int id) =>
        {
            //return new WeatherForecastRequest { ID = id };
        })
        .WithName("GetWeatherForecastRequestById")
        .Produces<WeatherForecastRequest>(StatusCodes.Status200OK);

        routes.MapPut("/api/WeatherForecastRequest/{id}", (int id, WeatherForecastRequest input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateWeatherForecastRequest")
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/WeatherForecastRequest/", (WeatherForecastRequest model) =>
        {
            //return Results.Created($"//api/WeatherForecastRequests/{model.ID}", model);
        })
        .WithName("CreateWeatherForecastRequest")
        .Produces<WeatherForecastRequest>(StatusCodes.Status201Created);

        routes.MapDelete("/api/WeatherForecastRequest/{id}", (int id) =>
        {
            //return Results.Ok(new WeatherForecastRequest { ID = id });
        })
        .WithName("DeleteWeatherForecastRequest")
        .Produces<WeatherForecastRequest>(StatusCodes.Status200OK);
    }
}}