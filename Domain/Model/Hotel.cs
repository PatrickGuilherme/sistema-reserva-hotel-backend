using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }
        public string CNPJ { get; set; }
        public string CEP { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Room> List_Room { get; set; }
    }
}
