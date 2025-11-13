namespace BlogApi.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string ? Title { get; set; }
        public string? Content { get; set; }
        public string? Category { get; set; }
        public List<string>? Tags { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
    }
}
