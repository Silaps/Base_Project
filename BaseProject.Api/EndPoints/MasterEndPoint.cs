using BaseProject.Application.Interfaces;
using BaseProject.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.EndPoints;

public static class MasterEndPoint
{
    public static void MapMasterEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/master");

        group.MapGet("get-form", GetFormById)
            .WithName("GetFormById");

        group.MapPost("add-form", AddForm)
            .WithName("AddForm");
    }

    private static async Task<IResult> GetFormById(int id, IMasterService masterService)
    {
        var form = await masterService.GetFormByIdAsync(id);
        return Results.Ok(form);
    }

    private static async Task<IResult> AddForm([FromBody] FormDTO formDto, IMasterService masterService)
    {
        var result = await masterService.AddFormAsync(formDto);
        return Results.Ok(result);
    }
}
