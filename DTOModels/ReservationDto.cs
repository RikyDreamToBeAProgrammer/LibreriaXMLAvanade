using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels
{
     public class ReservationDto
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
