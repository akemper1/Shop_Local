﻿using Plugin.CloudFirestore.Attributes;
using System.Collections.Generic;

namespace Shop_Local.Models
{
    public class Business
    {
        [MapTo("id")]
        public string ID { get; set; }

        [MapTo("name")]
        public string Name { get; set; }

        [MapTo("email")]
        public string Email { get; set; }

        [MapTo("phone_number")]
        public string PhoneNumber { get; set; }

        [MapTo("website")]
        public string Website { get; set; }

        [MapTo("street_number_and_name")]
        public string StreetNumberAndName { get; set; }

        [MapTo("city")]
        public string City { get; set; }

        [MapTo("zip_code")]
        public string ZipCode { get; set; }

        [MapTo("suite")]
        public string Suite { get; set; }

        [MapTo("category")]
        public string Category { get; set; }

        [MapTo("sub_category")]
        public IEnumerable<string> SubCategory { get; set; }

        [MapTo("additional_comments")]
        public string AdditionalComments { get; set; }

        [MapTo("approved")]
        public bool Approved { get; set; }

        [MapTo("recommended_by")]
        public string RecommendedBy { get; set; }
    }
}
