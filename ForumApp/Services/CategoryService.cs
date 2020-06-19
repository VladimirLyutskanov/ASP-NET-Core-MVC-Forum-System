using ForumApp.Data;
using ForumApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }
  
        public IEnumerable<Category> GetAll(int? count = null)
        {
            IEnumerable<Category> query = context.Categories.OrderBy(x => x.Name);

            if (count > 0)
            {
                query = query.Take(count.Value);
            }

            return query.ToList();
        }
    }
}
