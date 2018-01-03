using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BookMsg
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int RoomNum { get; set; }
        public int TableNum { get; set; }
        public DateTime BookTime { get; set; }
    }
}
