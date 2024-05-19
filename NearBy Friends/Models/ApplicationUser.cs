using Microsoft.AspNetCore.Identity;

namespace NearBy_Friends.Models
{
    public class ApplicationUser:IdentityUser
    {
  
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] ProfilePhoto { get; set; } // Binary data for the profile photo

        // Navigation properties for relationships
  
        //public ICollection<Friendship> Friendships { get; set; }
        //public ICollection<ChatMessage> SentMessages { get; set; }
        //public ICollection<ChatMessage> ReceivedMessages { get; set; }

    }
}
