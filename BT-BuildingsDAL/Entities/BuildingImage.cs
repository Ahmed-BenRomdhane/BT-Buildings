using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace BT_BuildingsDAL
{
    public class BuildingImage
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BuildingId { get; set; }
        [Required]
        public string BuildingImageUrl { get; set; }
        [ForeignKey("BuildingId")]
        public virtual Building Building { get; set; }
    }
}