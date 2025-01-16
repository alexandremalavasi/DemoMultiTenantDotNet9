using DemoMultiTenantDotNet9.Infrastructure;
using DemoMultiTenantDotNet9.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMultiTenantDotNet9.Logic
{
    public class CategoryLogic
    {
        private readonly SystemContext _systemContext;
        public CategoryLogic(SystemContext systemContext)
        {
            _systemContext = systemContext;
        }

        public async Task<List<Category>> List()
        {
            return await _systemContext.Category.ToListAsync();
        }
    }
}
