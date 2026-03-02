using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api.Extensions;

public static class HttpContextExtensions
{
    /// <summary>
    /// Gets the current user's ID from the JWT "sub" claim, or null if not authenticated or claim is missing/invalid.
    /// </summary>
    public static int? GetUserId(this HttpContext httpContext)
    {
        var sub = httpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sub)
                  ?? httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        return int.TryParse(sub, out var userId) ? userId : null;
    }
}
