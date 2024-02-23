using Application.Abstractions.Requests;
using Application.Abstractions.Responses;
using Domain.Entities;

namespace Application.Abstractions.Interfaces;

public interface IUserRepository: IGenericRepository<User>
{
    Task<IGenericPaginationResponse<User>> GetWithPagination(IGenericPaginationRequest pagination);
    Task<User?> GetByEmail(string email);
}
