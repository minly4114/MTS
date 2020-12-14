using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Data.Entities
{
    public class Call
    {
        public Cost Cost { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public Client Client { get; set; }
    }
}
