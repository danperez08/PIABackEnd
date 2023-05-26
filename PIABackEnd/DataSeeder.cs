namespace PIABackEnd;
using Microsoft.AspNetCore.Identity;
using System;

public static class DataSeeder
{
   
    public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        var roleExists = await roleManager.RoleExistsAsync("admin");
        if (!roleExists)
        {
            var adminRole = new IdentityRole("admin");
            await roleManager.CreateAsync(adminRole);
        }
    }
}
