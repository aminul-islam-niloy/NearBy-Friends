namespace NearBy_Friends.Models
{
    public class Friendship
    {
        public int Id { get; set; }

        // Foreign key for the user who initiated the connection
        //public string UserId { get; set; }
       // public ApplicationUser User { get; set; }

        // Foreign key for the friend
        public string FriendId { get; set; }
        public ApplicationUser Friend { get; set; }

        // Additional properties
        public bool IsAccepted { get; set; } // Indicates if the friendship request has been accepted
        public DateTime RequestDate { get; set; } // Date when the friendship request was sent
   
    
    
    }
}
