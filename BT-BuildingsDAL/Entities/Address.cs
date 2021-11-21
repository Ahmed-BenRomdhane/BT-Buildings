using System;
using System.ComponentModel.DataAnnotations;

namespace BT_BuildingsDAL
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter city name")]
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string HouseNumber { get; set; }
        [Required(ErrorMessage = "Please enter postal code")]
        public string PostalCode { get; set; }
        public string Province { get; set; }
        [Required(ErrorMessage = "Please enter street name")]
        public string StreetName { get; set; }
    }
}