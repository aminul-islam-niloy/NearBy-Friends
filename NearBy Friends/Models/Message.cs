namespace NearBy_Friends.Models
{
    public class Message
    {
        public int Id { get; set; }

        // Foreign key for the sender of the message
        public string SenderId { get; set; }
     //   public ApplicationUser Sender { get; set; }

        // Foreign key for the receiver of the message
        public string ReceiverId { get; set; }
      //  public ApplicationUser Receiver { get; set; }

        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        // Additional properties
        public bool IsRead { get; set; } // Indicates if the message has been read by the receiver
    }
}
