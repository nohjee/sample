using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData
{
    public class SchoolContext : DbContext
    {
        public DbSet<StudentModels> StudentModels { get; set; }
        public DbSet<EnrollmentModels> EnrollmentModelses { get; set; }
        public DbSet<CourseModels> CourseModelses { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
