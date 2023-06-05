using System;
using System.Collections.Generic;

namespace Diplom1
{
    public partial class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public int UsersId { get; set; }
        public string UsersName { get; set; } = null!;
        public string UsersSurname { get; set; } = null!;
        public string UsersSecondName { get; set; } = null!;
        public string UsersPassword { get; set; } = null!;
        public string UsersLogin { get; set; } = null!;
        public long? UsersPhone { get; set; }
        public int? UsersRolesid { get; set; }

        public virtual Role? UsersRoles { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
