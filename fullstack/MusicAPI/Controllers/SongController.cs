using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;
using MusicAPI.Data;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        // Fields
        private readonly DataContext _context; //Readonly - can only be assigned a value IN THE CONSTRUCTOR

        // Constructor
        public SongController( DataContext context)
        {
            this._context = context;
        }

        // Methods

        // GET: api/<SongController>
        // Richard
        [HttpGet]
        public async Task<ActionResult<List<Song>>> Get()
        {

            return Ok(await _context.Songs
                                        .Include(g => g.Genre)
                                        .Include(a => a.Artists)
                                        .ToListAsync()
                    );
        }

        // GET api/<SongController>/5
        // Vincent
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> Get(int id)
        {
            Song? getSong = await _context.Songs.FindAsync(id);
            if (getSong == null)
                return NotFound();

            return Ok(await _context.Songs
                                        .Include(g => g.Genre)
                                        .Include(a => a.Artists)
                                        .FirstAsync(s => s.Id == id)
                    );
        }

        // POST api/<SongController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Song newSong)
        {
            List<Song> songs = await _context.Songs.ToListAsync();
            foreach (Song s in songs)
            {
                if (s.Title == newSong.Title)
                    return Conflict(newSong);
            }

            // newSong is a Song object deserialized from the body of the request
            await _context.Songs.AddAsync(newSong);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Song>> Put(int id, [FromBody] Song update)
        {
            Song? song = await _context.Songs.FindAsync(id);
            if (song == null)
                return NotFound();
            
            song.Title = update.Title;
            //song.Artists = update.Artists;
            //song.Genre = update.Genre;
            song.RatingCount = update.RatingCount;
            song.TotalRating = update.TotalRating;
            song.Tempo = update.Tempo;

            await _context.SaveChangesAsync();
            return Ok(await _context.Songs.FindAsync(id));
        }

        // DELETE api/<SongController>/5
        // Paris
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Song? foundSong = await _context.Songs.FindAsync(id);
            if (foundSong == null)
            {
                return NotFound(); //404 not found
            } 
            else 
            {
                _context.Songs.Remove(foundSong);
                await _context.SaveChangesAsync();
                return NoContent(); //204 no content
            }
        }
    }
}
