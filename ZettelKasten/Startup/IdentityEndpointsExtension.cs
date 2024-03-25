using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ZettelKasten.Configurations;
using ZettelKasten.Models.Requests;

namespace ZettelKasten.Startup;

public static class IdentityEndpointsExtension
{
    public static RouteGroupBuilder IdentityGroup(this RouteGroupBuilder group)
    {
        group.MapPost("/Register", async ([FromBody] UserRegistrationRequest request,
            UserManager<IdentityUser> userManager,
            IOptions<JwtConfig> options) =>
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            
        });

        return group;
    }
}
