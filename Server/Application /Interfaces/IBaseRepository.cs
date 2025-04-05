using System;
using Microsoft.EntityFrameworkCore;
namespace Server.Application_.Interfaces;

public interface IBaseRepository<T>
{
    Task<T?> GetByIdAsync(int id); //something will be its type explore the not known types....but it will be a string tho or an object 
   // Task <IEnumerable<T>> GetAllValuesAsync(); 
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task AddAsync(T entity);
}
