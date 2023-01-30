using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Services.IServices;
using Dws.Note_one.Api.Domain.Repositories.IRepositories;
using Dws.Note_one.Api.Domain.Services.Communication;

namespace Dws.Note_one.Api.Domain.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork)
        {
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Store>> ListAsync()
        {
            return await _storeRepository.ListAsync();
        }

        public async Task<StoreResponse> SaveAsync(Store store)
        {
            try
            {
                await _storeRepository.AddAsync(store);
                await _unitOfWork.CompleteAsync();

                return new StoreResponse(store);
            }
            catch (Exception ex)
            {
                return new StoreResponse($"An error occurred when saving the store: {ex.Message}");
            }
        }

        public async Task<StoreResponse> UpdateAsync(int id, Store store)
        {

            var existingStore = await _storeRepository.FindByIdAsync(id);

            if (existingStore == null)
                return new StoreResponse("store not found.");

            existingStore.Name = store.Name;

            try
            {
                _storeRepository.Update(existingStore);
                await _unitOfWork.CompleteAsync();

                return new StoreResponse(existingStore);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new StoreResponse($"An error occurred when updating the store: {ex.Message}");
            }
        }

        public async Task<StoreResponse> DeleteAsync(int id)
        {
            var existingStore = await _storeRepository.FindByIdAsync(id);

            if (existingStore == null)
                return new StoreResponse("store not found.");

            try
            {
                _storeRepository.Delete(existingStore);
                await _unitOfWork.CompleteAsync();

                return new StoreResponse(existingStore);
            }
            catch (Exception ex)
            {
                return new StoreResponse($"An error occurred when deleting the store: {ex.Message}");
            }
        }
    }
}