using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ILBLI.Unity
{
    public static class UseAuthenticationExtension
    {
        public static IApplicationBuilder UseAuthenticationInit(this IApplicationBuilder app)
        {
            app.Map("/login", builder => builder.Use(next =>
            {
                return async (context) =>
                {
                    var claimIdentity = new ClaimsIdentity();
                    claimIdentity.AddClaim(new Claim(ClaimTypes.Name, ""));
                    await context.SignInAsync("ilbliScheme",new ClaimsPrincipal(claimIdentity));
                };
            }));

            return app;
        }
    }
}
