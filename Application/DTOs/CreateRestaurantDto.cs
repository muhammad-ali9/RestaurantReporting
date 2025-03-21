using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
