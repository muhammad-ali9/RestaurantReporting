using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
