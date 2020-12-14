using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Data.Entities
{
    public class Cost
    {
        public string Locality { get; set; }
        public decimal Value { get; set; }
        public decimal PreferentialValue { get; set; }
    }
}
