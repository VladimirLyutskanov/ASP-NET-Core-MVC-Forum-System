using ForumApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApp.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll (int? count = null);
    }
}
