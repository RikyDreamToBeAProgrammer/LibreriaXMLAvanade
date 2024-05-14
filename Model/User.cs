using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        private static int nextId = 1;
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role  Role { get; set; }
        public User() {
            //UserID = nextId;
            //nextId++;
        }

    }
    public enum Role
    {
        User = 1,
        Admin = 2
    }

}
