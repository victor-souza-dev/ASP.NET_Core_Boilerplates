using Application.Abstractions.Responses;
using Domain.Entities;

namespace Application.Abstractions.Interfaces;

public interface IUserRepository: IGenericRepository<User, GenericPagination>
{
    Task<UserPaginationResponse> GetWithPagination(GenericPagination pagination);
    Task<User?> GetByEmail(string email);
}
