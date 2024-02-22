using Application.Abstractions.Responses;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUserService: IGenericService<User>
{
    Task<UserPaginationResponse> GetWithPagination(GenericPagination pagination);
}
