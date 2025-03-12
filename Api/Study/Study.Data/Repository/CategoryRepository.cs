using Study.Core.Entities;
using Study.Core.Interface.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Data.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        readonly DataContext _datacontext;

        public CategoryRepository(DataContext context)
        {
            _datacontext = context;
        }

        public List<Category> GetAll()
        {
            return _datacontext.CategoryList.ToList();
        }
        public int GetIndexById(int id)
        {
            return _datacontext.CategoryList.ToList().FindIndex(u => u.Id == id);
        }

        public async Task<Category> AddAsync(Category category)
        {
            try
            {
                _datacontext.CategoryList.Add(category);
                 await   _datacontext.SaveChangesAsync();
                return category;
            }
            catch
            {
                return null;
            }
        }

        public Category? GetById(int id)
        {
            return _datacontext.CategoryList.Where(c => c.Id == id).FirstOrDefault();
        }

      

        public async Task<Category> UpdateAsync(Category category, int id)
        {
            var existingCategory = _datacontext.CategoryList.FirstOrDefault(c => c.Id == id);
            if (existingCategory ==null) return null;


            existingCategory.Name = category.Name;
            existingCategory.UpdateBy = category.UpdateBy;
            existingCategory.UpdateAt = DateTime.Now;

            try
            {
                await _datacontext.SaveChangesAsync();
                return category;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = _datacontext.CategoryList.FirstOrDefault(c => c.Id == id);
            if (category == null) return false;

            try
            {
                _datacontext.CategoryList.Remove(category);
                await  _datacontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
