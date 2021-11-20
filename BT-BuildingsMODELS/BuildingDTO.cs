using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_BuildingsMODELS
{
    public class BuildingDTO
    {
        public Guid Id { get; set; }
        public int TotalRooms { get; set; }
        public int TotalViews { get; set; }
        public int TotalLikes { get; set; }
        public decimal Area { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public bool IsFree { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public virtual ICollection<BuildingImageDTO> BuildingImages { get; set; }
        public AddressDTO Address { get; set; }
        public OwnerDTO Owner { get; set; }
    }
}
