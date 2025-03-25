using Domain.Common;

namespace Domain
{
    public class Users : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Navigation properties
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public ICollection<RestaurantTasks> CreatedTasks { get; set; }
        public ICollection<RestaurantTasks> ModifiedTasks { get; set; }
    }
}
