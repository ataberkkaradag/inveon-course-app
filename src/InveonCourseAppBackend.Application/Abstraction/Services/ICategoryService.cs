using InveonCourseAppBackend.Application.DTOs.Category;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Abstraction.Services
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task AddCategoryAsync(CategoryCreateDto categoryCreateDto);
        Task UpdateCategoryAsync(Guid id, CategoryUpdateDto categoryUpdateDto);
        Task DeleteCategoryAsync(Guid id);
    }
}
