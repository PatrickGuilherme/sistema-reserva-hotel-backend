using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IHotelService
    {
        public Task<HotelViewModel> SET_Hotel(HotelViewModel hotelViewModel);
    }
}