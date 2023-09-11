using demo1;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace empwebapi.data
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}


