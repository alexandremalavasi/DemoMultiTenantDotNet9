using DemoMultiTenantDotNet9.Logic;
using DemoMultiTenantDotNet9.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMultiTenantDotNet9.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        

        private readonly ILogger<CategoryController> _logger;
        private readonly CategoryLogic _categoryLogic;

        public CategoryController(ILogger<CategoryController> logger, CategoryLogic categoryLogic)
        {
            _logger = logger;
            _categoryLogic = categoryLogic;
        }

        [HttpGet]
        public async Task<List<Category>> List()
        {
            return await  _categoryLogic.List();
        }
    }
}
