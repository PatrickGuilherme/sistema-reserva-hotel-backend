using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IRoomService
    {
        public Task<IEnumerable<RoomViewModel>> GET_RoomAll(int hotelId);
        public Task<IEnumerable<RoomViewModel>> GET_Room();
        public Task<RoomViewModel> SET_Room(RoomViewModel roomViewModel);
        public Task<RoomViewModel> Modify_Status_Room(int idRoom);
        public Task<RoomReserveViewModel> ReserveRoom(int idRoom, int userID, DateTime dtInit, DateTime dtEnd);
    }
}
