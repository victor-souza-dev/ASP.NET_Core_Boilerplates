using Application.Abstractions.Interfaces;
using Application.Abstractions.Responses;
using Application.DTOs;
using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IoC;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        var assembly = Assembly.GetAssembly(typeof(DependencyInjection));

        services.AddDbContext<SQLiteDbContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("ctx"), b =>
        b.MigrationsAssembly(typeof(SQLiteDbContext).Assembly.FullName)));
        services.AddAutoMapper(assembly);

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGenericPaginationResponse<User>, UserPaginationDTO<User>>();

        services.AddTransient<QueryManipulator>();

        return services;
    }
}
