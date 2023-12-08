using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IRoomRepository
    {
        public Task<IEnumerable<Room>> GET_Room(int? id, int? roomNumber, int? floor, int? hotelID, bool? status);
        public Task<bool> DeleteRoom(int roomId);
        public Task<Room> SET_Room(int roomNumber, int floor, int hotelID);
        public Task<Room> Modify_Status_Room(int idRoom);
        public Task<RoomReserve> ReserveRoom(int idRoom, int userID, DateTime dtInit, DateTime dtEnd);
    }
}
