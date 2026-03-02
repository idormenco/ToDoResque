using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTodoDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TodoDbContext>(options =>
            options.UseSqlite(connectionString));
        
        return services;
    }
}
