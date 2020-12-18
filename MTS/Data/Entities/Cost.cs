using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Data.Entities
{
    public class Cost
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Locality { get; set; }
        public decimal Value { get; set; }
        public decimal PreferentialValue { get; set; }
        public List<Call> Calls { get; set; }
    }
}
