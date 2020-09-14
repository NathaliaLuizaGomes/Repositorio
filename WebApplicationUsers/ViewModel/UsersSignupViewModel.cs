using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUsers.Models;

namespace WebApplicationUsers.ViewModel
{
    public class UsersSignupViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public IEnumerable<PhonesModel> Phones { get; set; }

        public DateTime created_at { get; set; }

        public DateTime last_login { get; set; }

    }
}