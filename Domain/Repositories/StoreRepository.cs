using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Repositories.IRepositories;
using Dws.Note_one.Api.Persistence.Context;

namespace Dws.Note_one.Api.Domain.Repositories
{
    public class StoreRepository : BaseRepository, IStoreRepository
    {
        public StoreRepository(AppDbContext context) : base(context)
        {}

        public async Task<IEnumerable<Store>> ListAsync()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task AddAsync(Store store)
        {
            await _context.Stores.AddAsync(store);
        }

        public async Task<Store> FindByIdAsync(int id)
        {
            return await _context.Stores.FindAsync(id);

        }

        public void Update(Store store)
        {
            throw new NotImplementedException();
        }

        public void Delete(Store store)
        {
            _context.Stores.Remove(store);
        }
    }
}