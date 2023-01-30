using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Resource;
using Dws.Note_one.Api.Domain.Services.IServices;
using Dws.Note_one.Api.Mapping;
using Dws.Note_one.Api.Extension;

namespace Dws.Note_one.Api.Controllers
{
    [Route("/api/[controller]")]

    public class StoreController : Controller
    {
        private readonly IStoreService 
        _storeService;
        private readonly IMapper _mapper;

        public StoreController(IStoreService storeService, IMapper mapper) {

            _storeService = storeService;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            var stores = await _storeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Store>, IEnumerable<StoreResource>>(stores);
            //return resources;
            return stores;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveStoreResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var store = _mapper.Map<SaveStoreResource, Store>(resource);
            var result = await _storeService.SaveAsync(store);

            if(!result.Success)
                return BadRequest(result.Message);

            var storeResource = _mapper.Map<Store, StoreResource>(result.Store);
                return Ok(storeResource);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteStoreResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var store = _mapper.Map<DeleteStoreResource, Store>(resource);
            var result = await _storeService.DeleteAsync(store.Id);

            if(!result.Success)
                return BadRequest(result.Message);

            var storeResource = _mapper.Map<Store, StoreResource>(result.Store);
                return Ok(storeResource);
        }

    }
}