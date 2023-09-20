using Assistant.Service.AuthAPI.Models;

namespace Assistant.Service.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser application, IEnumerable<string> roles);
    }
}
