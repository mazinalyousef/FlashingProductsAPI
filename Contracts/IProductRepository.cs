using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
     public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(int CategoryId, bool trackChanges);

        Product GetProduct(int categoryID, int ProductId, bool trackChanges);


        void CreateProduct(int CategoryId, Product product);


        void DeleteProduct(Product product);

    }
}
