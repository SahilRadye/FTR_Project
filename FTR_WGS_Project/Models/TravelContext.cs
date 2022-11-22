using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FTR_WGS_Project.Models
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class TravelContext : DbContext
    {
        public TravelContext() : base("name = connstr")
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Travel> Travels { get; set; }

        public DbSet<GCM> GCMs { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<TravelDetail> TravelDetails { get; set; }

        public DbSet<EmployeeFamilyInformation> EmployeeFamilyInformations { get; set; }

        public DbSet<AssignmentDetail> AssignmentDetails { get; set; }

        public DbSet<AssignmentContact> AssignmentContacts { get; set; }
    }
}