using AutoMapper;
using Study.Core.DTOs;
using Study.Core.Entities;
using Study.Core.Interface.IntarfaceService;
using Study.Core.Interface.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Study.Services
{
    public class CategoryService : ICategoryService
    {
        readonly IRepository<Category> _categoryRepository;
        readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            var categoryList =_categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoryList);
        }

        public  CategoryDTO GetCategoryById(int id)
        {
            var categoryEntity =_categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<CategoryDTO> UpdateCategoryAsync(int id, CategoryDTO category)
        {
            
            if (id < 0)
                return null;
            var Category = _mapper.Map<Category>(category);
            var result =await _categoryRepository.UpdateAsync(Category, id);
            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task<CategoryDTO> AddCategoryAsync(CategoryDTO category)
        {
            var Category = _mapper.Map<Category>(category);
            if (_categoryRepository.GetById(Category.Id) == null)
            {
                var createdCategory = await _categoryRepository.AddAsync(Category);
                return _mapper.Map<CategoryDTO>(createdCategory);
            }
            return null;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            
            if (id < 0) return false;

           await _categoryRepository.DeleteAsync(id);
            return true;
        }
    }
}
