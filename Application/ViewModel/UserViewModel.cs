using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class UserViewModel
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? TypeUser { get; set; }//1-Hotel | 2-Cliente
        public int? HotelId { get; set; }
}
}
