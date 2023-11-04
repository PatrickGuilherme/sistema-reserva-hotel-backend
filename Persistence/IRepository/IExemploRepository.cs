using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IExemploRepository
    {
        public Task<IEnumerable<Exemplo>> GET_Exemplo(int pulo, int limite, int? id, string nome, double? valor, bool? ativo);

        public Task<Exemplo> GETBY_Exemplo(int id);

        public Task<IEnumerable<Exemplo>> GETSQL_Exemplo();
    }
}
