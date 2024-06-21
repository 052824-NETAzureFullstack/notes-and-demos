using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Controllers.Models;
using Controllers.Data;


namespace Controllers.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly DataContext _context;

        public PetsController(DataContext context)
        {
            this._context = context;
        }

        // GET: api/<PetsController>
        [HttpGet]
        public async Task<ActionResult<List<Pet>>> Get()
        {
            // Instantiate the list...
            List<Pet> petsList = new List<Pet>();

            // fill the list?
            petsList = await this._context.Pets.ToListAsync();

            // return the list, wrapped by a 200 http response code
            return Ok(petsList); //200 OK
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> Get(int id)
        {
            Pet? pet = await _context.Pets.FindAsync(id);
            if (pet == null)
                return NotFound();
            else
                return Ok(pet);
        }

        // POST api/<PetsController>
        [HttpPost]
        public async Task<ActionResult<Pet>> Post([FromBody] Pet newPet)
        // async wraps the return in a boolean value that dentes if the method is done running yet.
        // Task<T> turns true when the method is complete, and the return T is ready.
        {
            _context.Pets.Add(newPet);
            await _context.SaveChangesAsync();

            List<Pet> pets = await _context.Pets.ToListAsync(); // Gather the data for the LINQ query


            //enumerable - we can count them
            //I - an interface, Enumerable 0 tings become countable
            // IEnumerable means we can iterate throuh them!
            // foreach ( var ITEM in IEnumerable ) - we MUST use an IEnumerable to run the foreach!
            // List<T>, Array<T>
            var iPet = //IEnumerable<T> where T is whatever kind of object was in the data source
                from p in pets
                where (p.Name == newPet.Name) && (p.Cuteness == newPet.Cuteness)
                select p; // this is the LINQ heavy lifting, querying our data source (the list from above) and returning the matching values

            // IEnumerable<T> != List<T>
            // so we have to convert to something we can index, like a list!

            pets = iPet.ToList();
          
            return Ok(await _context.Pets.FindAsync(pets[0].ID));
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Pet>> Put(int id, [FromBody] Pet updatePet)
        {
            Pet? pet = await _context.Pets.FindAsync(id);
            if (pet == null)
                return NotFound();

            // if (pet != null)...
            pet.ID = updatePet.ID;
            pet.Name = updatePet.Name;
            pet.Cuteness = updatePet.Cuteness;

            await _context.SaveChangesAsync();

            return Ok(await _context.Pets.FindAsync(id));
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Pet? lostPet = await _context.Pets.FindAsync(id);
            if (lostPet == null)
            {
                return NotFound(); // 404 no resource found
            }                
            else
            {
                _context.Pets.Remove(lostPet);
                await _context.SaveChangesAsync();
                return NoContent(); //204 no content
            }
        }
    }
}
