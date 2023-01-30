using System.Collections.Generic;
using System.Threading.Tasks;
using Dws.Note_one.Api.Domain.Models;

namespace Dws.Note_one.Api.Domain.Repositories.IRepositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> ListAsync();
        Task AddAsync(Store store);
        Task<Store> FindByIdAsync(int id);
        void Update(Store store);
        void Delete(Store store);
    }
}