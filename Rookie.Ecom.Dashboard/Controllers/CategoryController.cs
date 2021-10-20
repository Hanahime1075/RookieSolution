using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Dashboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(
            ILogger<CategoryController> logger,
            ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateAsync([FromBody] CategoryDto categoryDto)
        {
            Ensure.Any.IsNotNull(categoryDto, nameof(categoryDto));
            var asset = await _categoryService.AddAsync(categoryDto);
            return Created("/category", asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] CategoryDto categoryDto)
        {
            Ensure.Any.IsNotNull(categoryDto, nameof(categoryDto));
            Ensure.Any.IsNotNull(categoryDto.Id, nameof(categoryDto.Id));
            await _categoryService.UpdateAsync(categoryDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var categoryDto = await _categoryService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(categoryDto, nameof(categoryDto));
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<CategoryDto> GetByIdAsync(Guid id)
            => await _categoryService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAsync()
        {
            return await _categoryService.GetAllAsync();
        }
    }
}
