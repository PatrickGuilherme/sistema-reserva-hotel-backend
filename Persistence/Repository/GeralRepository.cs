using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Context;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class GeralRepository : IGeralRepository
    {
        private readonly DataContext _context;

        public GeralRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public EntityEntry<T> Delete<T>(T Entity) where T : class
        {
            var entry = _context.Remove(Entity);
            return entry;
        }

        public EntityEntry<T> Update<T>(T Entity) where T : class
        {
           return _context.Update(Entity);
        }

        public async Task<bool> SaveChangesAsyncs()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
