using LoginAppAPI.Data.DBConfig;
using LoginAppAPI.Data.Interfaces;
using LoginAppAPI.Data.Repositories;
using LoginAppAPI.Models;
using LoginAppAPI.Services;
using LoginAppAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("TestDB"));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();

    if (!context.Usuarios.Any())
    {
        context.Usuarios.Add(new Usuario("admin", "P@$$W0RD") { Id = 1 });
        context.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();