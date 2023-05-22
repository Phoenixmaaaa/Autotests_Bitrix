using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.TestEntities
{
    public class User
    {
        public User (string login, string password, string nick = "")
        {
            this.Login = login;
            this.Password = password;
            this.Nick = nick;
        }

        public User ()
        {

        }
        public string Login { get; set; }
        public string Password { get; set; }

        public string Nick { get; set; }
    }
}
