using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Filter
{
    public class RoomReserveDto
    {
        public int UserID { get; set; }
        public int RoomID { get; set; }
        public DateTime DtInit { get; set; }
        public DateTime DtEnd { get; set; }
    }
}
