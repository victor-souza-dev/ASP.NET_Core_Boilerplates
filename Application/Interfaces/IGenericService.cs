using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IGenericService<T, Pagination>
{
    Task<List<T>> GetAll();
    Task<List<T>> GetWithPagination(Pagination pagination);
    Task<T> GetById(int id);
    void Create(T body);
    void Update(string id, T body);
    void Delete(string id);
}
