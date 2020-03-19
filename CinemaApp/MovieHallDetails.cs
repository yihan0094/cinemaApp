using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp
{
    class MovieHallDetails
    {
        public int Id { get; set; }
        public int MovieHallId { get; set; }
        public string Seats { get; set; }
        public EnumSeatStatus  SeatStatus{ get; set; }
    }

public enum EnumSeatStatus
{
    Empty,Taken
}
}
