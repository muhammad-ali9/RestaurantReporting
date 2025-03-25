using Domain.Common;

namespace Domain
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }

        public ICollection<RestaurantSerialNumber> SerialNumbers { get; set; } = new List<RestaurantSerialNumber>();
        public ICollection<RestaurantTasks> RestaurantTasks { get; set; }
    }

}
