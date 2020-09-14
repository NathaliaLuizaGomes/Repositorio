using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationUsers.Models;

namespace WebApplicationUsers.Tests
{
    public class UserServiceFake : IUserService
    {
        private readonly List<UsersSignupModel> _usersSignups;

        public UserServiceFake()
        {
            _usersSignups = new List<UsersSignupModel>()
            {                
                new UsersSignupModel() { IdUser = 1, FirstName = "Tablet SamSung 7",
                                   LastName ="SamSung", Email = "mariaa@gmail.com",
                                    Password = "0000", created_at = DateTime.Now, last_login = DateTime.Now},
                new UsersSignupModel() { IdUser = 1, FirstName = "Tablet SamSung 7",
                                   LastName ="SamSung", Email = "mariaa@gmail.com",
                                    Password = "0000", created_at = DateTime.Now, last_login = DateTime.Now},
                new UsersSignupModel() { IdUser = 1, FirstName = "Tablet SamSung 7",
                                   LastName ="SamSung", Email = "mariaa@gmail.com",
                                    Password = "0000", created_at = DateTime.Now, last_login = DateTime.Now },
                new UsersSignupModel() { IdUser = 1, FirstName = "Tablet SamSung 7",
                                   LastName ="SamSung", Email = "mariaa@gmail.com",
                                    Password = "0000", created_at = DateTime.Now, last_login = DateTime.Now}
            };
        }

        public IEnumerable<UsersSignupModel> GetAllItems()
        {
            return _usersSignups;
        }
        public UsersSignupModel Add(UsersSignupModel novoItem)
        {
            novoItem.IdUser = GeraId();
            _usersSignups.Add(novoItem);
            return novoItem;
        }
        public UsersSignupModel GetById(int id)
        {
            return _usersSignups.Where(a => a.IdUser == id)
                .FirstOrDefault();
        }
        public void Remove(int id)
        {
            var item = _usersSignups.First(a => a.IdUser == id);
            _usersSignups.Remove(item);
        }
        static int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }

    }
}

