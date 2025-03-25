using Domain.Common;

namespace Domain
{
    public class RestaurantSerialNumber : BaseEntity
    {
        public int SerialNumber { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public Restaurant? Restaurant { get; set; }
        public ICollection<RestaurantTasks> RestaurantTasks { get; set; }
    }

}
