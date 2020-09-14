using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplicationUsers.Models
{
    public partial class UserDBContext : DbContext
    {
        public UserDBContext() 
            : base("name=UserDBContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }
                
        public virtual DbSet<UsersSignupModel> UsersSignupModel { get; set; }
    }
}