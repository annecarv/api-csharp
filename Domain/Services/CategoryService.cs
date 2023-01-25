using System.Collections.Generic;
using System.Threading.Tasks;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Services.IServices;
using Dws.Note_one.Api.Persistence.Repositories.IRepositories;
using Dws.Note_one.Api.Domain.Services.Communication;

namespace Dws.Note_one.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new SaveCategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<SaveCategoryResponse> UpdateAsync(int id, Category category)
        {

            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new SaveCategoryResponse("Category not found.");

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveCategoryResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<SaveCategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new SaveCategoryResponse("Category not found.");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new SaveCategoryResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }

        Task<SaveCategoryResponse> ICategoryService.SaveAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}