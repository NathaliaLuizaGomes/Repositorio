using System.Collections.Generic;
using WebApplicationUsers.Models;

namespace WebApplicationUsers.Tests
{
    public interface IUserService
    {
        IEnumerable<UsersSignupModel> GetAllItems();
        UsersSignupModel Add(UsersSignupModel newItem);
        UsersSignupModel GetById(int id);
        void Remove(int id);
    }
}