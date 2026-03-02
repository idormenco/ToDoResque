using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public interface IApplicationDbContext
{
    DbSet<TodoItem> TodoItems { get; }
    DbSet<User> Users { get; }
}