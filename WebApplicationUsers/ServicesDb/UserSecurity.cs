using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplicationUsers.Models;
using WebApplicationUsers.Util;

namespace WebApplicationUsers.ServicesDb
{
    public class UserSecurity
    {

        public static bool Login(string email, string password)
        {
            using (UserDBContext entities = new UserDBContext())
            {              

                return entities.UsersSignupModel.Any(user =>
                    user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                    && user.Password == password);
            }
        }
    }
}