using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        Category GetCategory(int categoryId, bool trackChanges);

        void DeleteCategory(Category category);
    }
}
