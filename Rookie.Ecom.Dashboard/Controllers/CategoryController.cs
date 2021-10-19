using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
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

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAsync()
        {
            return await _categoryService.GetAllAsync();
        }
    }
}
