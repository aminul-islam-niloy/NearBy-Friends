namespace NearBy_Friends.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumer { get; set; }
        public int Age { get; set; }    

        public string Profession { get; set; }
        public string Hobbies { get; set; }

    }

}
