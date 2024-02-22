using Application.Abstractions.Interfaces;
using Application.Abstractions.Responses;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

    public async Task<UserPaginationResponse> GetWithPagination(GenericPagination pagination) {
        return await _userRepository.GetWithPagination(pagination);
    }
}
