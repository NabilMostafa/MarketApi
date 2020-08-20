using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Market.Api.Resources;
using Market.Core.Models;
using Market.Core.Services;

namespace Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this._mapper = mapper;
            this._categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CategoryResource>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            var categoryResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

            return Ok(categoryResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResource>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            var categoryResource = _mapper.Map<Category, CategoryResource>(category);

            return Ok(categoryResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CategoryResource>> CreateCategory([FromBody] SaveCategoryResource saveCategoryResource)
        {
           
            var categoryToCreate = _mapper.Map<SaveCategoryResource, Category>(saveCategoryResource);
            var newCategory = await _categoryService.CreateCategory(categoryToCreate);

            var category = await _categoryService.GetCategoryById(newCategory.Id);

            var categoryResource = _mapper.Map<Category, CategoryResource>(category);

            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryResource>> UpdateCategory(int id,
            [FromBody] SaveCategoryResource saveCategoryResource)
        {
            
            var categoryToBeUpdated = await _categoryService.GetCategoryById(id);

            if (categoryToBeUpdated == null)
                return NotFound();

            var category = _mapper.Map<SaveCategoryResource, Category>(saveCategoryResource);

            await _categoryService.UpdateCategory(categoryToBeUpdated, category);

            var updatedCategory = await _categoryService.GetCategoryById(id);

            var updatedCategoryResource = _mapper.Map<Category, CategoryResource>(updatedCategory);

            return Ok(updatedCategoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            await _categoryService.DeleteCategory(category);

            return NoContent();
        }
    }
}