namespace CRUD.HTTPClientShowCase
{
    public class User
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Name Name { get; set; }

        public Address Address { get; set; }

        public string Phone { get; set; }
    }

    public class Name
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class Address
    {
        public string City { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string ZipCode { get; set; }

        public GeoLocation GeoLocation { get; set; }
    }

    public class GeoLocation
    {
        public string Lat { get; set; }

        public string Long { get; set; }
    }

}
