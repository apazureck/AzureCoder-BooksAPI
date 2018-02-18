using System.ComponentModel.DataAnnotations;

namespace OData.Locations.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}