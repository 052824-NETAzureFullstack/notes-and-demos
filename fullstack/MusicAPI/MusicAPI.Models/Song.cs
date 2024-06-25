using Microsoft.EntityFrameworkCore;

namespace MusicAPI.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public int RatingCount { get; set; }
        public int TotalRating { get; set; }
        public double AverageRating { get; set;}
        public Genre Genre { get; set; }
        public int Tempo { get; set; }
    }
}