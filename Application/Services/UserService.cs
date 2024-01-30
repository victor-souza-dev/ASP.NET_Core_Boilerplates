using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Create(User body)
    {
        _userRepository.Create(body);
    }

    public void Delete(string id)
    {
        _userRepository.Delete(id);
    }

    public Task<List<User>> GetAll()
    {
        return _userRepository.GetAll();
    }

    public Task<User> GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public Task<List<User>> GetWithPagination(GenericPagination pagination)
    {
        return _userRepository.GetWithPagination(pagination);
    }

    public void Update(string id, User body)
    {
        _userRepository.Update(id, body);
    }
}
