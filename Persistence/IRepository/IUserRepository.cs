using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IUserRepository
    {
        public Task<User> Login(string email, string password);
        public bool LoginTest(string email, string password);

    }
}
