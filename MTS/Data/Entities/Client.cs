using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Data.Entities
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
    }
}
