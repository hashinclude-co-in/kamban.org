using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class UserRepository : IUserRepository
    {
        private UserContext _ctx;

        public UserRepository(UserContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<User> GetAllUsers()
        {
            return _ctx.Users;
        }
    }
}
