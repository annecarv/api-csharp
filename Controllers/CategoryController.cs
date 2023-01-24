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

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper) {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return categories;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if(!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
                return Ok(categoryResource);
        }

    }
}