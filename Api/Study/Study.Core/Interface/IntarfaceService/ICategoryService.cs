using Study.Core.DTOs;
using Study.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Study.Core.Interface.IntarfaceService
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategoryById(int id);
        Task<CategoryDTO> UpdateCategoryAsync(int id, CategoryDTO category);
        Task<CategoryDTO> AddCategoryAsync(CategoryDTO category);
        Task<bool> DeleteCategoryAsync(int id);

    }
}
