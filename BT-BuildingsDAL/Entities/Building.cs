using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace BT_BuildingsDAL
{
    public class Building
    {
        [Key]
        public Guid Id { get; set; }
        public int TotalRooms{ get; set; }
        public int TotalViews { get; set; }
        public int TotalLikes { get; set; }
        [Range(10, 1000)]
        public decimal Area { get; set; }
        [Required(ErrorMessage = "Please enter building price")]
        public double Price { get; set; }
        public string Description{ get; set; }
        [Required(ErrorMessage = "Please enter building name")]
        public string Name { get; set; }
        public string Status { get; set; }
        public bool IsFree { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public virtual ICollection<BuildingImage> BuildingImages { get; set; }
        public Address Address { get; set; }
        public Owner Owner { get; set; }
    }
}