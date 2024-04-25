using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NorthWind.Models;
using NorthWind.SeedData;

namespace NorthWind.Helper;

public static class DatabaseStartUp
{
    public static IApplicationBuilder UseApplicationDatabase<T>(this IApplicationBuilder app,
        IServiceProvider serviceProvider)
    {

        using (var scope = serviceProvider.CreateScope())
        {
            //var services = scope.ServiceProvider;
            var context = serviceProvider.GetRequiredService<NorthWindDbContext>();
            context.Database.Migrate();
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            IdentitySeedData.Seed(context, userMgr, roleMgr).Wait();
        }

        return app;
    }
}