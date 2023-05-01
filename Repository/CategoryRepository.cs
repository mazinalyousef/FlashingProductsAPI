using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;

namespace Repository
{
    public class CategoryRepository :RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
       : base(repositoryContext)
        {
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.Title)
        .ToList();

        public Category GetCategory(int categoryId, bool trackChanges)
        => FindByCondition(c => c.Id.Equals(categoryId), trackChanges).SingleOrDefault();
    }
}
