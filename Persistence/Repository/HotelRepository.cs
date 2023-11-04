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
    public class HotelRepository : IHotelRepository
    {
        private readonly DataContext _context;
        private readonly IGeralRepository _geralRepository;
        private bool test = false;
        private Mock mock;

        public HotelRepository(DataContext context, IGeralRepository geralRepository)
        {
            _context = context;
            _geralRepository = geralRepository;
        }

        public async Task<IEnumerable<Hotel>> GET_Hotel(int? id, string name, string cep, string cnpj)
        {
            try
            {
                IQueryable<Hotel> query = _context.DB_Hotel
                    .Where(x => (id == null || x.ID == id) &&
                                (string.IsNullOrEmpty(name) || x.Name.Contains(name)) &&
                                (string.IsNullOrEmpty(cep) || x.CEP.Contains(cep)) &&
                                (string.IsNullOrEmpty(cnpj) || x.CNPJ.Contains(cnpj)));
                query = query.AsNoTracking();
                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroConsultaBancoDados);
            }
        }

        public async Task<Hotel> SET_Hotel(string name, string description, string cnpj, string cep, string address)
        {
            try
            {
                Hotel hotel = new Hotel { Name = name, Descrition = description, CEP = cep, CNPJ = cnpj, Address = address };
                _geralRepository.Add(hotel);
                if(!await _geralRepository.SaveChangesAsyncs()) throw new Exception("");
                return hotel;
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroCadastroBancoDados);
            }
        }
      

        public async Task<Hotel> UPDATE_Hotel(int id, string name, string description, string cnpj, string cep, string address)
        {
            try
            {
                Hotel hotel = new Hotel {ID = id, Name = name, Descrition = description, CEP = cep, CNPJ = cnpj, Address = address };

                _geralRepository.Update(hotel);
                if (!await _geralRepository.SaveChangesAsyncs()) throw new Exception("");
                return hotel;
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroCadastroBancoDados);
            }
        }
    }
}
