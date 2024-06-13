namespace HTTPConsumer.DTO
{
    public class Post
    {
        // Fields
        // DTO - Data Transfer Object
        public int userId { get; set; }
        public int id { get; set; }
        public string? title { get; set; }
        public string? body { get; set; }
    }
}