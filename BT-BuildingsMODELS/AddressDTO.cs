using System;

namespace BT_BuildingsMODELS
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string StreetName { get; set; }
    }
}