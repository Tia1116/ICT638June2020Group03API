using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ICT638June2020Group03API.models;


namespace ICT638June2020Group03API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HouseController : ControllerBase
    {
        private readonly HouseContext _context;
        private List<House> hourseTestList = new List<House>();

        public HouseController(HouseContext context)
        {
            _context = context;



            for (int i=0; i < 100; i++)
            {
                House house = new House();
                house.Address = "city2001" + i;
                house.id = i;
                house.bedroomnumber = i + 1 + "";
                house.bathroomnumber = i + 3 + "";
                house.rent = i * 100 + 100;
                hourseTestList.Add(house);

            }
        }

        // GET: api/Houses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetAllHouse()
        {
            //  return await _context.TodoItems.ToListAsync();



            return hourseTestList;

        }

        [HttpGet("{rent}")]
        public async Task<ActionResult<House>> GetHouseByRent(float rent)
        {
            House result = null;

            foreach (House tempHouse in hourseTestList)
            {

                if (rent == tempHouse.rent)
                {
                    result = tempHouse;
                }
            }
            return result;
        }

        // GET: api/Houses/5
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

        // PUT: api/Houses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(int id, House house)
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

        // POST: api/Houses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<House>> PostAgent(House house)
        {
            _context.TodoItems.Add(house);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHouse", new { id = house.id }, house);
        }

        // DELETE: api/Houses/5  yifan
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
