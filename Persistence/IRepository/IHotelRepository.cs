using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IHotelRepository
    {
        public Task<IEnumerable<Hotel>> GET_Hotel(int? id, string name, string cep, string cnpj);

        public Task<Hotel> SET_Hotel(string name, string description, string cnpj, string cep, string address);

        public Task<Hotel> UPDATE_Hotel(int id, string name, string description, string cnpj, string cep, string address); 
    }
}
