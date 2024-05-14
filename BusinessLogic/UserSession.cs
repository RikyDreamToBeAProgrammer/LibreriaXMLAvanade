using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserSession
    {
        private static UserSession instance = null;
        public User CurrentUser { get; private set; }

        private UserSession() { }

        public static UserSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserSession();
                }
                return instance;
            }
        }

        public void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }

        public void ClearSession()
        {
            CurrentUser = null;
        }
    }

}
