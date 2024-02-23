using Application.Abstractions.Interfaces;
using Application.Abstractions.Responses;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : PaginationRepository<User>, IUserRepository
{
    private readonly SQLiteDbContext _ctx;
    private readonly IGenericPaginationResponse<User> _response;

    public UserRepository(SQLiteDbContext ctx, IGenericPaginationResponse<User> response) {
        _ctx = ctx;
        _response = response;
    }
    protected override IQueryable<User> GetItemsQuery(string formattedQuery) {
        return _ctx.User
            .OrderBy(p => p.Name)
            .Where(p => p.Name.ToLower().Replace(" ", "").Contains(formattedQuery));
    }

    protected override IGenericPaginationResponse<User> CreateList(List<User> items, int totalCount, bool hasNext) {
        _response.HasNext = hasNext;
        _response.TotalCount = totalCount;
        _response.Items = items;

        return _response;
    }

    public Task<List<User>> GetAll()
    {
        return _ctx.User.ToListAsync();
    }

    public async Task<User?> GetById(Guid id)
    {
        return await _ctx.User.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async void Create(User body) {
        await _ctx.AddAsync(body);
        await _ctx.SaveChangesAsync();
    }

    [AsyncTransaction]
    public async void Update(Guid id, User body)
    {
        User? user = await this.GetById(id);

        if(user == null) {
            throw new Exception("Usuário não existe!");
        }

        user.Update(body.Name, body.Email, body.Password);

        _ctx.User.Update(user);
        await _ctx.SaveChangesAsync();
    }

    [AsyncTransaction]
    public async void Delete(Guid id)
    {
        User? user = await this.GetById(id);

        if(user == null) {
            throw new Exception("Usuário não existe!");
        }

        _ctx.User.Remove(user);
        await _ctx.SaveChangesAsync();
    }

    public async Task<User?> GetByEmail(string email) {
        return await _ctx.User.FirstOrDefaultAsync(x => x.Email == email);
    }
}
