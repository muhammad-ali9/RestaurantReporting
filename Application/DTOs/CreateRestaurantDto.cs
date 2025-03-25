using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
     public class CreateRestaurantDto
    {
        [Required]
        public string CityName { get; set; }
        [Required]
        public int SerialNumber { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
