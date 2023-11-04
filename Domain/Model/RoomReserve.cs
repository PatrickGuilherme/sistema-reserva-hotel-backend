using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class RoomReserve
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public virtual Room Room { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }
    }
}
