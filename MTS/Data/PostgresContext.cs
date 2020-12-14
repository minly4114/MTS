using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Data
{
    public class PostgresContext:DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options)
        {
        }
    }
}
