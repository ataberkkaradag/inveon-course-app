
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Category;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonCourseAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category=await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryCreateDto categoryCreateDto) 
        {
            await _categoryService.AddCategoryAsync(categoryCreateDto);
            return Ok( categoryCreateDto);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory( CategoryUpdateDto categoryUpdateDto) 
        {
            
            await _categoryService.UpdateCategoryAsync(categoryUpdateDto.Id,categoryUpdateDto);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }

    }
}
