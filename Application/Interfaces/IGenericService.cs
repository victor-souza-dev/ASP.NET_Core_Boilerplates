﻿namespace Application.Interfaces;

public interface IGenericService<T>
{
    Task<List<T>> GetAll();
    Task<T> GetById(Guid id);
    void Create(T body);
    void Update(Guid id, T body);
    void Delete(Guid id);
}
