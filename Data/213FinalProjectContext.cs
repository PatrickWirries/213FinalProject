using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _213FinalProject.Models;

namespace _213FinalProject.Data
{
    public class _213FinalProjectContext : DbContext
    {
        public _213FinalProjectContext(DbContextOptions<_213FinalProjectContext> options)
            : base(options)
        {
        }


       public DbSet<_213FinalProject.Models.User> User { get; set; } = default!; 
       public DbSet<_213FinalProject.Models.Service> Service { get; set; } = default!;
       public DbSet<_213FinalProject.Models.Appointment> Appointment { get; set; } = default!;
 
       
        public DbSet<_213FinalProject.Models.Customer> Customer { get; set; } = default!;
        public DbSet<_213FinalProject.Models.Employee> Employee { get; set; } = default!;
        public DbSet<_213FinalProject.Models.Receptionist> Receptionist { get; set; } = default!;
        public DbSet<_213FinalProject.Models.ServicePerforming> ServicePerforming{ get; set; } = default!;
        public DbSet<_213FinalProject.Models.Manager> Manager { get; set; } = default!;
        public DbSet<_213FinalProject.Models.ServicePerformingEmployeeService> ServicePerformingEmployeeService { get; set; } = default!;


    }
}
