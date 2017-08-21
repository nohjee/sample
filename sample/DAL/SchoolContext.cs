using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using sample.Models;

namespace sample.DAL
{
    public class SchoolContext : DbContext
    {
        public DbSet<StudentModels> StudentModelses { get; set; }
        public DbSet<EnrollmentModels> EnrollmentModelses { get; set; }
        public DbSet<CourseModels> CourseModelses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}