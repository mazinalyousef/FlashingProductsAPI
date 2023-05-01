using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashingProductsAPI.Controllers
{
    [Route("api/categories/{categoryId}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductsController(IRepositoryManager repository, ILoggerManager logger,
IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductsForCategory(int categoryId)
        {
            var category = _repository.Category.GetCategory(categoryId, trackChanges: false);
            if (category == null)
            {
                _logger.LogInfo($"category with id: {categoryId} doesn't exist in the database.");
                return NotFound();
            }
            var AllProducts = _repository.Product.GetProducts(categoryId,
            trackChanges: false);


            var currentTime = DateTime.Now;

            var currentProducts= AllProducts.Where(p => p.StartDate.HasValue
            && p.StartDate <= currentTime
            && ((DateTime)p.StartDate).AddSeconds(p.Durationseconds ?? 0) >= currentTime);

            var ProductsDto = _mapper.Map<IEnumerable<ProductDto>>(currentProducts);
            return Ok(ProductsDto);


        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(int categoryId,int id)
        {
            var category = _repository.Category.GetCategory(categoryId, trackChanges: false);
            if (category == null)
            {
                _logger.LogInfo($"category with id: {categoryId} doesn't exist in the database.");
                return NotFound();
            }

            var product= _repository.Product.GetProduct(categoryId,id, trackChanges: false);
            if (product == null)
            {
                _logger.LogInfo($"product with id: {id} doesn't exist in the database.");
                return NotFound();            
            }
            else
            {
                var productdto = _mapper.Map<ProductDto>(product);
                return Ok( productdto);
            }
        }


        [HttpPost]
        public IActionResult CreateProduct(int CategoryID, [FromBody]
        ProductCreateDto productDto)
        {
            if (productDto == null)
            {
                _logger.LogError("product object sent from client is null.");
                return BadRequest("product object is null");
            }
            var category = _repository.Category.GetCategory(CategoryID, trackChanges: false);
            if (category == null)
            {
                _logger.LogInfo($"category with id: {CategoryID} doesn't exist in the database.");
                 return NotFound();
            }


            var productEntity = _mapper.Map<Product>(productDto);
            _repository.Product.CreateProduct(CategoryID, productEntity);
            _repository.Save();
            var productToReturn = _mapper.Map<ProductDto>(productEntity);
            return CreatedAtRoute("GetProduct", new
            {
                CategoryID,
                id =
                productToReturn.Id
            }, productToReturn);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int CategoryId, int id)
        {
            var category = _repository.Category.GetCategory(CategoryId, trackChanges:false);
            if (category == null)
            {
                _logger.LogInfo($"Category with id: {CategoryId} doesn't exist in the database.");
                return NotFound();
            }

            var product = _repository.Product.GetProduct(CategoryId, id, trackChanges: false);
            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Product.DeleteProduct(product);
            _repository.Save();

            return NoContent();
        }



        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int CategoryId, int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            var category = _repository.Category.GetCategory(CategoryId, trackChanges: false);
            if (category == null)
            {
                _logger.LogInfo($"Category with id: {CategoryId} doesn't exist in the database.");
                return NotFound();
            }
            var productfromdatabase = _repository.Product.GetProduct(CategoryId, id, trackChanges: true); // track changes to retrived product
            if (productfromdatabase == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            if (productUpdateDto == null)
            {
                _logger.LogError("productUpdateDto object sent from client is null.");
                return BadRequest("productUpdateDto object is null");
            }

            _mapper.Map(productUpdateDto, productfromdatabase);
            _repository.Save();

            return NoContent();

        }





    }
}
