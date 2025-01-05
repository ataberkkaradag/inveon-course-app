using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Category;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task AddCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
            var category=new Category
            {
                Name = categoryCreateDto.Name
            };
            await _categoryRepository.CreateAsync(category);
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            var category= await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new Exception("category not found");
            }
            return category;
        }

        public async Task UpdateCategoryAsync(Guid id, CategoryUpdateDto categoryUpdateDto)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);
             existingCategory.Name= categoryUpdateDto.Name;
            
            await _categoryRepository.UpdateAsync(existingCategory.Id,existingCategory);
        }
    }
}
