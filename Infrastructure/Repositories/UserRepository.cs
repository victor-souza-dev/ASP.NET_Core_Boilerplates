using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SQLiteDbContext _ctx;

    public UserRepository(SQLiteDbContext ctx)
    {
        _ctx = ctx;
    }

    public void Create(User body)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAll()
    {
        return _ctx.User.ToListAsync();
    }

    public Task<List<User>> GetWithPagination(GenericPagination pagination)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(int id)
    {
        throw new NotImplementedException();
    }

    [AsyncTransaction]
    public void Update(string id, User body)
    {
        throw new NotImplementedException();
    }

    [AsyncTransaction]
    public void Delete(string id)
    {
        throw new NotImplementedException();
    }
}
