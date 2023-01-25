using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Persistence.Repositories.IRepositories;
using Dws.Note_one.Api.Persistence.Context;

namespace Dws.Note_one.Api.Domain.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {}

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddSync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public Task AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }

        public void Remove(Category category)
        {
            throw new NotImplementedException();
        }
    }
}