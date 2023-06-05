using System;
using System.Collections.Generic;

namespace Diplom1
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Rolesid { get; set; }
        public int Role1 { get; set; }
        public int UsersUsersId { get; set; }

        public virtual User UsersUsers { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }
    }
}
