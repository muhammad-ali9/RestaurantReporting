using Domain.Common;

namespace Domain
{
    public class RestaurantTasks : BaseEntity
    {
        public string FormId { get; set; }
        public string SerialNo { get; set; }
        public int CityId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public City City { get; set; }
        public Users CreatedByUser { get; set; }
        public Users? ModifiedByUser { get; set; }
    }
}
