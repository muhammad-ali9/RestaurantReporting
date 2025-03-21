using Domain.Common;

namespace Domain
{
    public class Restaurant : BaseEntity
    {
        public string RestaurantName { get; set; }
        public string Address { get; set; }
        public int SerialNumberId { get; set; }
        public RestaurantSerialNumber SerialNumber { get; set; }
    }

}
