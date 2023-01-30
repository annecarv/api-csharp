using System.Collections.Generic;
using System.Threading.Tasks;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Services.Communication;

namespace Dws.Note_one.Api.Domain.Services.IServices
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> ListAsync();
        Task<StoreResponse> SaveAsync(Store store);
        Task<StoreResponse> UpdateAsync(int id, Store store);
        Task<StoreResponse> DeleteAsync(int id);
    }
}