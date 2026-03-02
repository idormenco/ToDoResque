using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Seeders;

public static class IdentitySeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<TodoDbContext>();

        await CreateUser(userManager, "alice@example.com", "string");
        await CreateUser(userManager, "bob@example.com", "string");
    }

    private static async Task CreateUser(
        TodoDbContext context,
        string email,
        string password)
    {
        if (await context.Users.FirstOrDefaultAsync(x => x.Email == email) != null)
            return;

        var user = new User
        {
            Email = email,
            Password = BCrypt.Net.BCrypt.HashPassword(password),
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }
}