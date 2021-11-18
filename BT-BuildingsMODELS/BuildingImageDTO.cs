using System;

namespace BT_BuildingsMODELS
{
    public class BuildingImageDTO
    {
        public Guid Id { get; set; }
        public Guid BuildingId { get; set; }
        public string BuildingImageUrl { get; set; }
    }
}