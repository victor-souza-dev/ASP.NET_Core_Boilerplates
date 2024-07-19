using Application.Abstractions.Requests;
using Application.Abstractions.Responses;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUserService: IGenericService<User>
{
    Task<UserPaginationDTO<UserResponseDTO>> GetWithPagination(IGenericPaginationRequest pagination);
}
