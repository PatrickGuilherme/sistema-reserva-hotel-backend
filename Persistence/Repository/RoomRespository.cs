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
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;
        private readonly IGeralRepository _geralRepository;
        private bool test = false;
        private Mock mock;
        public RoomRepository(bool _test)
        {
            test = _test;

            mock = new Mock();
        }

        public RoomRepository(DataContext context, IGeralRepository geralRepository)
        {
            _context = context;
            _geralRepository = geralRepository;
        }

        public async Task<IEnumerable<Room>> GET_Room(int? id, int? roomNumber, int? floor, int? hotelID, bool? status)
        {
            try
            {
                IQueryable<Room> query = _context.DB_Room
                    .Where(x => (id == null || x.ID == id) &&
                                (roomNumber == null || x.RoomNumber == roomNumber) &&
                                (floor == null || x.Floor == floor) &&
                                (hotelID == null || x.HotelID == hotelID) &&
                                (status == null || x.Status == status)
                          );
                query = query.AsNoTracking();
                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroConsultaBancoDados);
            }
        }

        public async Task<Room> SET_Room(int roomNumber, int floor, int hotelID)
        {
            try
            {
                bool status = true;
                Room hotel = new Room { RoomNumber = roomNumber, Floor = floor, HotelID = hotelID, Status = status};
                _geralRepository.Add(hotel);
                if (!await _geralRepository.SaveChangesAsyncs()) throw new Exception("");
                return hotel;
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroCadastroBancoDados);
            }
        }

        public async Task<Room> Modify_Status_Room(int idRoom)
        {
            try
            {
                var result = await GET_Room(idRoom, null, null, null, null);
                if (result == null || result.Count() != 1) throw new Exception("");
                Room room = result.FirstOrDefault();
                room.Status = !room.Status;
                _geralRepository.Update(room);
                await _geralRepository.SaveChangesAsyncs();
                return room;
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroCadastroBancoDados);
            }
        }
    }
    
}
