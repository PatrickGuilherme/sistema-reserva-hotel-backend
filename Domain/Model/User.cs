using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TypeUser { get; set; }//1-Hotel | 2-Cliente
        public virtual ICollection<RoomReserve> List_RoomReserve { get; set; }
        public int? HotelId { get; set; }

    }
}
