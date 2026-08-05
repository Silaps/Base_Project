namespace BaseProject.Api.Endpoints;

public static class CityEndPoint
{
    public static void MapCityEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/cities");

        group.MapGet("get-all", GetAllCities)
            .WithName("GetAllCities");
    }

    private static async Task<IResult> GetAllCities()
    {
        //var cities = await cityService.GetAllCitiesAsync();
        return Results.Ok();
    }


}