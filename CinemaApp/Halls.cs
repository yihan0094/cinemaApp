using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp
{
    class Halls
    {
        public int Id { get; set; }
        public string HallNo { get; set; }

        public int TotalRow { get; set; }
        public int TotalColumn { get; set; }
        public int TotalSeats => TotalRow * TotalColumn;
    }
}
