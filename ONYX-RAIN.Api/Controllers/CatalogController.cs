using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ONYX.RAIN.Data;              
using ONYX.RAIN.Domain.Catalog;    

namespace ONYX.RAIN.Api.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;  // Dependency injection of StoreContext

        public CatalogController(StoreContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_db.Items); // Fetching items from the database through Entity Framework
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = _db.Items.Find(id); // Querying a single item by ID from the database
            if (item == null)
            {
                return NotFound(); // Return NotFound if the item does not exist
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            _db.Items.Add(item); // Adding a new item to the database
            _db.SaveChanges();  // Saving changes to the database
            return Created($"/catalog/{item.Id}", item); // Return the URI of the created item and the item itself
        }
        

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = _db.Items.Find(id); // Find the item to add the rating to
            if (item == null)
            {
                return NotFound();
            }
            item.AddRating(rating); // Add the rating to the item
            _db.SaveChanges();      // Save changes to the database
            
            return Ok(item);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutItem(int id, [FromBody] Item item)
        {
            
            if (id != item.Id)
            {
                return BadRequest();
            }
            
            if (_db.Items.Find(id) == null)
            {
                return NotFound();
            }
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _db.Items.Remove(item); // Remove the item from the database
            _db.SaveChanges();
            return Ok(); // Return a 204 No Content response
        }
    }
}