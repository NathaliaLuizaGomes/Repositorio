using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationUsers.Models;

namespace WebApplicationUsers.Tests.Services
{
    public class UserService : IUserService
    {
        public UsersSignupModel Add(UsersSignupModel novoItem)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UsersSignupModel> GetAllItems()
        {
            throw new NotImplementedException();
        }
        public UsersSignupModel GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
