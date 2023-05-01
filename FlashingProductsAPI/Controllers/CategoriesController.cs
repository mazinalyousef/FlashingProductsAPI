using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashingProductsAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CategoriesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            try
            {
                var categories = _repository.Category.GetAllCategories(trackChanges: false);
                var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
                return Ok(categoriesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCategories)}action {ex}");
                 return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category= _repository.Category.GetCategory(id, trackChanges: false);
            if (category == null)
            {
                _logger.LogInfo($"Category with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return Ok(categoryDto);
            }
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _repository.Category.GetCategory(id, trackChanges: false);
            if (category == null)
            {
                _logger.LogInfo($"Category with id: { id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Category.DeleteCategory(category);
            _repository.Save();

            return NoContent();
        }
    }
}
