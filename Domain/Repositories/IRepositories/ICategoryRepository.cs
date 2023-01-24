using System.Collections.Generic;
using System.Threading.Tasks;
using Dws.Note_one.Api.Domain.Models;

namespace Dws.Note_one.Api.Domain.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();

        Task AddSync(Category category);
    }
}