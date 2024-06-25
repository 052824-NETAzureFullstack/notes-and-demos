using Microsoft.EntityFrameworkCore;

namespace MusicAPI.Models
{
    public class Genre
    {
       public int Id { get; set; }
       public string Name { get; set; } = ""; 
       public List<Song> Song { get; set; } = new List<Song>();
    }
}