using Microsoft.EntityFrameworkCore;

namespace Controllers.Models
{
    public class Pet
    {
        public int ID { get; set; }
        public string? Name { get; set; } = "";
        public int? Cuteness { get; set; }
    }
}