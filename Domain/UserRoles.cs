namespace Domain
{
    public class UserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        //Navigation properties
        public virtual Users User { get; set; }
        public virtual Roles Role { get; set; }

    }
}
