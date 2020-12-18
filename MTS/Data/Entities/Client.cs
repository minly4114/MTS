using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Data.Entities
{
    public class Client
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public List<Call> Calls { get; set; }
    }
}
