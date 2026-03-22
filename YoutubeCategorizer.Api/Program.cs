using Microsoft.EntityFrameworkCore;
using YoutubeCategorizer.Api.Data;
using YoutubeCategorizer.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<YoutubePlaywrighService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=youtube.db"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
