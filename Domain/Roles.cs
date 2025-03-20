using Domain.Common;

namespace Domain
{
    public class Roles : BaseEntity
    {
        public string RoleName { get; set; }

        //Navigation properties
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
