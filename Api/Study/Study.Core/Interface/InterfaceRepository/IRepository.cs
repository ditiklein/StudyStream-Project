using Study.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.Interface.InterfaceRepository
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T GetById(int id);
        int GetIndexById(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T book, int index);
        Task<bool> DeleteAsync(int index);
    }
}
