using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksAPI.Models;
using ParksAPI.Interfaces;
using Newtonsoft.Json;

namespace ParksAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksAPIContext _db;
    private readonly IParkRepository _repository;

    public ParksController(ParksAPIContext db, IParkRepository repository)
    {
      _db = db;
      _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> GetParks(string state)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();

      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    [HttpGet]
    [Route("paging-filter")]
    public IActionResult GetParkPagingData([FromQuery] PagedParameters parkParameters)
    {
        var park = _repository.GetParks(parkParameters);

        var metadata = new
        {
            park.TotalCount,
            park.PageSize,
            park.CurrentPage,
            park.TotalPages,
            park.HasNext,
            park.HasPrevious
        };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(park);
    }

    [HttpGet]
    [Route("getpaging-by-param")]
    public async Task<ActionResult<IEnumerable<Park>>> GetParksByFilter(PagedParameters parkParameters)
    {
        if (_db.Parks == null)
        {
            return NotFound();
        }
        return await _db.Parks.OrderBy(on => on.ParkId)
      .Skip((parkParameters.PageNumber - 1) * parkParameters.PageSize)
      .Take(parkParameters.PageSize).ToListAsync();
    }
    
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Parks.Update(park);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }
  
  }
}