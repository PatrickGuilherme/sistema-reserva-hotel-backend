using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IGeralRepository
    {
        void Add<T>(T Entity) where T : class;
        EntityEntry<T> Update<T>(T Entity) where T : class;
        Task<bool> SaveChangesAsyncs();
    }
}
