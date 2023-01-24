using System.Collections.Generic;
using System.Threading.Tasks;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Services.Communication;

namespace Dws.Note_one.Api.Domain.Services.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<SaveCategoryResponse> SaveAsync(Category category);
    }
}