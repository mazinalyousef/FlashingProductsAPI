using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Repository
{
   public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public ICategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_repositoryContext);
                return _categoryRepository;
            }
        }
        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_repositoryContext);
                return _productRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();
    }
}
