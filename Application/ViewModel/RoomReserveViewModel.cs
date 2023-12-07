using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class RoomReserveViewModel
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public virtual RoomViewModel Room { get; set; }
        public int UserID { get; set; }
        public virtual UserViewModel User { get; set; }
        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }
    }
}
