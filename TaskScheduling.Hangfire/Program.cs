using Hangfire;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Hangfire.SQLite;
using Domain.Interfaces;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHangfire((sp, config) =>
{
    var connectionString = sp.GetRequiredService<IConfiguration>().GetConnectionString("ctx");
    config.UseSQLiteStorage(connectionString);
});
builder.Services.AddDbContext<SQLiteDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ctx")));

builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
