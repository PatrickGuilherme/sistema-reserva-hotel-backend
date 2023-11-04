using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Room
    {
        public int ID { get; set; }
        public int RoomNumber { get; set; }//Numero quarto
        public int Floor { get; set; }//andar
        public int HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }
        public bool Status { get; set; }//Ativado/desativado
        public virtual ICollection<RoomReserve> List_RoomReserve { get; set; }

    }
}
