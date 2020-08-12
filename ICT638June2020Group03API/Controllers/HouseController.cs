using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ICT638June2020Group03API.models;


namespace ICT638June2020Group03API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly HouseContext _context;

        public HouseController(HouseContext context)
        {
            _context = context;
        }

        // GET: api/Agents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Agents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouse(int id)
        {
            var house = await _context.TodoItems.FindAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            return house;
        }

        // PUT: api/Agents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgent(int id, House house)
        {
            if (id != house.id)
            {
                return BadRequest();
            }

            _context.Entry(house).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(id))
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

        // POST: api/Agents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Agent>> PostAgent(House house)
        {
            _context.TodoItems.Add(house);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgent", new { id = house.id }, house);
        }

        // DELETE: api/Agents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<House>> DeleteAgent(int id)
        {
            var house = await _context.TodoItems.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(house);
            await _context.SaveChangesAsync();

            return house;
        }

        private bool HouseExists(int id)
        {
            return _context.TodoItems.Any(e => e.id == id);
        }
    }
}
