using Microsoft.AspNetCore.Mvc;
using osu_buckeye_api.Domain.Catalog;
using osu_buckeye_api.Data;

namespace osu-buckeye-api.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogController : ControllerBase
{
    private readonly StoreContext _db;

    public CatalogController(StoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetItems() => Ok(_db.Items.ToList());

    [HttpGet("{id:int}")]
    public IActionResult GetItem(int id)
    {
        var item = _db.Items.Find(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public IActionResult Post(Item item)
    {
        _db.Items.Add(item);
        _db.SaveChanges();
        return Created($"/catalog/{item.Id}", item);
    }

    [HttpPost("{id:int}/ratings")]
    public IActionResult PostRating(int id, [FromBody] Rating rating)
    {
        var item = _db.Items.Find(id);
        if (item == null) return NotFound();
        
        item.AddRating(rating);
        _db.SaveChanges();
        return Ok(item);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, Item item)
    {
        if (id != item.Id) return BadRequest();
        
        _db.Entry(item).State = EntityState.Modified;
        _db.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var item = _db.Items.Find(id);
        if (item == null) return NotFound();
        
        _db.Items.Remove(item);
        _db.SaveChanges();
        return Ok();
    }
}