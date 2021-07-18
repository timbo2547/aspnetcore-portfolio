using AspNetCorePostgreSQLDockerApp.Models;
using AspNetCorePostgreSQLDockerApp.Repository;
using AspNetCorePostgreSQLDockerApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePostgreSQLDockerApp.APIs
{

    [Route("api/[controller]/sampleitems")]
    public class SampleItemServiceController : Controller
    {
        ISampleItemRepository _repo;
        public SampleItemServiceController(ISampleItemRepository repo)
        {
            _repo = repo;
        }

        // GET api/dataservice/customers
        [HttpGet()]
        [ProducesResponseType(typeof(List<SampleItem>), 200)]
        [ProducesResponseType(typeof(List<SampleItem>), 404)]
        public async Task<ActionResult> SampleItems()
        {
            var sampleItems = await _repo.GetSampleItemsAsync();
            if (sampleItems == null)
            {
                return NotFound();
            }
            return Ok(sampleItems);
        }

        // GET api/dataservice/customers/5
        [HttpGet("{id}", Name = "GetSampleItemRoute")]
        [ProducesResponseType(typeof(SampleItem), 200)]
        [ProducesResponseType(typeof(SampleItem), 404)]
        public async Task<ActionResult> SampleItems(int id)
        {
            var sampleItem = await _repo.GetSampleItemAsync(id);
            if (sampleItem == null)
            {
                return NotFound();
            }
            return Ok(sampleItem);
        }

        // POST api/customers
        [HttpPost()]
        [ProducesResponseType(typeof(SampleItem), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> PostSampleItem([FromBody] NewSampleItemDto newSampleItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var newSampleItem = await _repo.InsertSampleItemDtoAsync(newSampleItemDto);
            if (newSampleItem == null)
            {
                return BadRequest("Unable to insert Sample Item");
            }
            return CreatedAtRoute("GetSampleItemRoute", new { id = newSampleItem.Id }, newSampleItem);
        }
    }
}
