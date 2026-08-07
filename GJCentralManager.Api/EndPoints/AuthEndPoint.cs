using GJCentralManager.Application.Interfaces;
using GJCentralManager.Domain.Dtos;
using GJCentralManager.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GJCentralManager.Api.EndPoints;

public class AuthEndPoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth").WithTags("Authentication");

        group.MapPost("/register", async (RegisterDto request, UserManager<ApplicationUser> userManager) =>
        {
            var user = new ApplicationUser { UserName = request.Email, Email = request.Email };
            var result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return Results.Ok(new { message = "Usuario registrado exitosamente." });
            }

            return Results.BadRequest(result.Errors);
        });

        group.MapPost("/login", async (LoginDto request, UserManager<ApplicationUser> userManager, ITokenService tokenService) =>
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
            {
                return Results.Unauthorized();
            }

            var roles = await userManager.GetRolesAsync(user);
            var token = tokenService.GenerateJwtToken(user, roles);

            return Results.Ok(new AuthResponseDto
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(60) // Esto podría venir del JwtOptions
            });
        });
    }
}
