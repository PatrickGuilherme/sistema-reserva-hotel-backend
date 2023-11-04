using Domain.Model;
using Domain.MsgErro;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IGeralRepository _geralRepository;
        private bool test;
        private Mock mock;

        public UserRepository()
        {
            mock = new Mock();
        }

        public UserRepository(DataContext context, IGeralRepository geralRepository)
        {
            _context = context;
            _geralRepository = geralRepository;
        }

        public async Task<User> Login(string email, string password)
        {
            try
            {
                IQueryable<User> query = _context.DB_User
                .Where(x => (x.Email == email) && (x.Password == password));
                query = query.AsNoTracking();
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new Exception(MsgErro.ErroLogin);
            }
        }

        public bool LoginTest(string email, string password)
        {
            try
            {
                 var x = mock.list_User.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                return x != null ? true : false;
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroLogin);
            }
        }
    }
}
