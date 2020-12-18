using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Data.Entities
{
    public class Call
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdCost { get; set; }
        public Cost Cost { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public int IdClient { get; set; }
        public Client Client { get; set; }
        public int NumberOfMinutes { get; set; }
        public int PreferentialNumberOfMinutes { get; set; }
        public decimal Sum { get; set; }
        public Payment Payment { get; set; }

    }
}
