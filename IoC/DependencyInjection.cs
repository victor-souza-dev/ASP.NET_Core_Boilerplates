using Application.Abstractions.Interfaces;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Context;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<SQLiteDbContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("ctx"), b =>
        b.MigrationsAssembly(typeof(SQLiteDbContext).Assembly.FullName)));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddTransient<QueryManipulator>();

        return services;
    }
}
