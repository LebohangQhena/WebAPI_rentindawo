using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public class user
    {
        public string user_name;
        public string user_surname;
        public string user_email;
        public string user_numbers;
        public string user_password;

        public user(string user_name, string user_surname, string user_numbers, string user_email)
        {
            this.user_name = user_name;
            this.user_surname = user_surname;
            this.user_email = user_email;
            this.user_numbers = user_numbers;
            //this.user_password = user_password;
        }

        public string getname()
        {
            return user_name;
        }

        public string getsurname()
        {
            return user_surname;
        }

        public string getemail()
        {
            return user_email;
        }

        public string getnumbers()
        {
            return user_numbers;
        }
    }
}