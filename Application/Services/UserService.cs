using Application.Abstractions.Interfaces;
using Application.Abstractions.Requests;
using Application.Abstractions.Responses;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<List<User>> GetAll() {
        return _userRepository.GetAll();
    }

    public async Task<User> GetById(Guid id) {
        User? user = await _userRepository.GetById(id);

        if (user == null) {
            throw new Exception("Nenhum usuário encontrado!");
        }

        return user;
    }

    public async void Create(User body)
    {
        User? user = await _userRepository.GetByEmail(body.Email);

        if(user != null) {
            throw new Exception("Usuário já existe!");
        }

        _userRepository.Create(body);
    }

    public void Update(Guid id, User body)
    {
        _userRepository.Update(id, body);
    }
    
    public void Delete(Guid id) {
        _userRepository.Delete(id);
    }

    public async Task<UserPaginationDTO<UserResponseDTO>> GetWithPagination(IGenericPaginationRequest pagination) {
        IGenericPaginationResponse<User> paginationResponse = await _userRepository.GetWithPagination(pagination);

        var mappedItems = _mapper.Map<List<User>, List<UserResponseDTO>>(paginationResponse.Items);

        var userPaginationDTO = new UserPaginationDTO<UserResponseDTO> {
            Items = mappedItems,
            TotalCount = paginationResponse.TotalCount,
            HasNext = paginationResponse.HasNext
        };

        return userPaginationDTO;
    }
}
