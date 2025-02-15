﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Seat:IEntity
    {
        [Key]
        public int seat_id { get; set; }
        public int trip_id{ get; set; }
        public int seat_number { get; set; }
        public bool is_reserved { get; set; }


        public Trip Trip { get; set; }
    }
}
