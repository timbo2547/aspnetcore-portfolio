using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimPortfolioApp.Dtos;
using TimPortfolioApp.Models;
using TimPortfolioApp.Repository;

namespace TimPortfolioApp.APIs
{
    [Route("api/[controller]/categories")]
    public class CategoryServiceController : Controller
    {
        ICategoryRepository _repo;
        public CategoryServiceController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        // GET api/dataservice/categories
        [HttpGet()]
        [ProducesResponseType(typeof(List<Category>), 200)]
        [ProducesResponseType(typeof(List<Category>), 404)]
        public async Task<ActionResult> Categories()
        {
            var sampleItems = await _repo.GetCategoriesAsync();
            if (sampleItems == null)
            {
                return NotFound();
            }
            return Ok(sampleItems);
        }

        // GET api/dataservice/customers/5
        [HttpGet("{id}", Name = "GetCategoryRoute")]
        [ProducesResponseType(typeof(Category), 200)]
        [ProducesResponseType(typeof(Category), 404)]
        public async Task<ActionResult> Categories(int id)
        {
            var sampleItem = await _repo.GetCategoryAsync(id);
            if (sampleItem == null)
            {
                return NotFound();
            }
            return Ok(sampleItem);
        }

        //// POST api/categories
        //[HttpPost()]
        //[ProducesResponseType(typeof(Category), 201)]
        //[ProducesResponseType(typeof(string), 400)]
        //public async Task<ActionResult> PostCategoryItem([FromBody] Category category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(this.ModelState);
        //    }

        //    var newCustomer = await _repo.InsertCategoryAsync(category);
        //    if (newCustomer == null)
        //    {
        //        return BadRequest("Unable to insert Category");
        //    }
        //    return CreatedAtRoute("CategoryRoute", new { id = newCustomer.Id }, newCustomer);
        //}

        // POST api/categories
        [HttpPost()]
        [ProducesResponseType(typeof(Category), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> PostCategoryItemByName([FromBody] NewCategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var newCustomer = await _repo.InsertCategoryDtoAsync(category);
            if (newCustomer == null)
            {
                return BadRequest("Unable to insert Category");
            }
            return CreatedAtRoute("GetCategoryRoute", new { id = newCustomer.Id }, newCustomer);
        }


    }
}
