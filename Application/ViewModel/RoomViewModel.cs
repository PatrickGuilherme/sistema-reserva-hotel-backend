using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class RoomViewModel
    {
        public int? ID { get; set; }
        public int? RoomNumber { get; set; }//Numero quarto
        public int? Floor { get; set; }//andar
        public int? HotelID { get; set; }
        public virtual HotelViewModel Hotel { get; set; }
        public bool? Status { get; set; }//Ativado/desativado
    }
}
