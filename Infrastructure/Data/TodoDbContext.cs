using Domain.Entities;
using Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoItemConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
