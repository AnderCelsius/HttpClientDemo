
using HttpClientDemo.Api.Data;
using HttpClientDemo.Api.Routes;
using Microsoft.EntityFrameworkCore;

namespace HttpClientDemo.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TodoList"));
      builder.Services.AddDatabaseDeveloperPageExceptionFilter();

      // Add services to the container.
      builder.Services.AddAuthorization();

      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();

      // map Routes
      app.MapTodoRoutes();

      app.Run();
    }
  }
}
