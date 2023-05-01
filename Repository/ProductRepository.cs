using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
   public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
         public ProductRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreateProduct(int CategoryId, Product product)
        {
            product.CategoryID = CategoryId;
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public Product GetProduct(int categoryID, int ProductId, bool trackChanges) =>
            FindByCondition(p => p.Id.Equals(ProductId)&&p.CategoryID.Equals(categoryID), trackChanges).SingleOrDefault();
         

        public IEnumerable<Product> GetProducts(int CategoryId, bool trackChanges) =>
            FindByCondition(p => p.CategoryID.Equals(CategoryId), trackChanges).OrderBy(p => p.Title);
         
    }
}
