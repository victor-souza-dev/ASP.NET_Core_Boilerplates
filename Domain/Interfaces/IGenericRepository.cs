using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces;

public interface IGenericRepository<T, Pagination>
{
    Task<List<T>> GetAll();
    Task<List<T>> GetWithPagination(Pagination pagination);
    Task<T> GetById(int id);
    void Create(T body);
    void Update(string id, T body);
    void Delete(string id);
}
