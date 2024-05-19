namespace NearBy_Friends.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public int Likecount { get; set; }
        public bool Like { get; set;}

        public string Comments { get; set; }

    }
}
