using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Study.API.Models;
using Study.Core.DTOs;
using Study.Core.Entities;
using Study.Core.Interface.IntarfaceService;
using Study.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Study.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService _categoryService;
        readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: api/Category
        [HttpGet]
        public  ActionResult<IEnumerable<CategoryDTO>> Get()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        // GET api/Category/5
        [HttpGet("{id}")]
        public  ActionResult<CategoryDTO> GetById(int id)
        {
            if (id < 0) return BadRequest();

            var result = _categoryService.GetCategoryById(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST api/Category
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] CategoryPostModel category)
        {
            if (category == null) return BadRequest("User data is required");
            var CategoryD = _mapper.Map<CategoryDTO>(category);
            var result =await _categoryService.AddCategoryAsync(CategoryD);
            if (result == null) return BadRequest("User already exists or could not be added");
            return Ok(result);
        }

        // PUT api/Category/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody] CategoryPostModel category)
        {
            if (category == null || id < 0) return BadRequest("Invalid input");
            var LessonD = _mapper.Map<CategoryDTO>(category);
            var result =await _categoryService.UpdateCategoryAsync(id, LessonD);
            if (result == null) return NotFound("User not found");
            return Ok(result.Id);
        }

        // DELETE api/Category/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if ( id < 0) return BadRequest("Invalid input");
            bool result =await _categoryService.DeleteCategoryAsync(id);
            return result ? Ok(result) : NotFound("User not found or could not be deleted");
        }
    }
}
