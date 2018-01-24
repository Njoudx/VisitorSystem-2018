using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VisitorSystem.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<IDType> IDTypes { get; set; }
        public DbSet<Status> Statusz { get; set; }
        public DbSet<RequestRejectionReason> RequestRejectionReasons { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Authorizor> Authorizors { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public ApplicationDbContext()
            :base("name=DefaultConnection")
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}