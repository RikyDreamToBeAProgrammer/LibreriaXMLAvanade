using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reservation
    {
        private static int nextId = 1;
        public int Id { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public Reservation() {
            //Id = nextId;
            //nextId++;
        }


    }
}
