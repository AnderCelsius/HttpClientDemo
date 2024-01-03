using HttpClientDemo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace HttpClientDemo.Api.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

  public DbSet<Todo> Todos => Set<Todo>();
}