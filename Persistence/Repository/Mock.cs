using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class Mock
    {
        public List<Hotel> list_Hotel { get; set; }
        public List<Room> list_Room { get; set; }
        public List<User> list_User { get; set; }

        public Mock()
        {
            User us1 = new User { Email = "u1@gmail.com", Name = "u1", Password = "123456", TypeUser = 1 };
            User us2 = new User { Email = "u2@gmail.com", Name = "u2", Password = "123456", TypeUser = 2 };
            User us3 = new User { Email = "u3@gmail.com", Name = "u3", Password = "123456", TypeUser = 1 };
            List<User> list_users = new List<User>();
            list_users.Add(us1);
            list_users.Add(us2);
            list_users.Add(us3);
            list_User = list_users;
        }
    }
}
