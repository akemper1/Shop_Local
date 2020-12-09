using Plugin.CloudFirestore.Attributes;

namespace Shop_Local.Models
{
    public class Business
    {
        [MapTo("name")]
        public string Name { get; set; }

        [MapTo("email")]
        public string Email { get; set; }

        [MapTo("phone_number")]
        public string PhoneNumber { get; set; }

        [MapTo("website")]
        public string Website { get; set; }

        [MapTo("street_number")]
        public int StreetNumber { get; set; }

        [MapTo("street_name")]
        public string StreetName { get; set; }

        [MapTo("city")]
        public string City { get; set; }

        [MapTo("zip_code")]
        public int ZipCode { get; set; }

        [MapTo("category")]
        public string Category { get; set; }
    }
}
