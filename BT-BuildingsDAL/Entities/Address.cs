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
        [Required(ErrorMessage = "Please enter country code")]
        public string CountryCode { get; set; }
        [Required(ErrorMessage = "Please enter house number")]
        public string HouseNumber { get; set; }
        [Required(ErrorMessage = "Please enter postal code")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Please enter province name")]
        public string Province { get; set; }
        [Required(ErrorMessage = "Please enter street name")]
        public string StreetName { get; set; }
    }
}