using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Trip: IEntity
    {
        [Key]
        public int trip_id { get; set; }
        public string departure_city { get; set; }
        public string arrival_city { get; set; }
        public DateTime departure_time { get; set; }
        public int price { get; set; }

        public List<Seat> Seats { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
