using GJCentralManager.Domain.Entities;

namespace GJCentralManager.Application.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(ApplicationUser user, IList<string> roles);
}
