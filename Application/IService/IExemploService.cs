using Application.Filter;
using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IExemploService
    {
        public Task<IEnumerable<ExemploViewModel>> GET_Exemplo(int pulo, int limite, ExemploFiltro filtro);

        public Task<IEnumerable<ExemploViewModel>> GETSQL_Exemplo();

        public Task<ExemploViewModel> Create(ExemploViewModel exemplo);

        public Task<ExemploViewModel> Update(ExemploViewModel exemplo);

        public Task<ExemploViewModel> Disable(int id);
    }
}
