using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMS.Models;

namespace UMS.Data
{
    public class UMSContext : DbContext
    {
        public UMSContext (DbContextOptions<UMSContext> options)
            : base(options)
        {
        }

        public DbSet<UMS.Models.Course> Course { get; set; } = default!;

        public DbSet<UMS.Models.Student>? Student { get; set; }

        public DbSet<UMS.Models.CourseRegistration>? CourseRegistration { get; set; }

        public DbSet<UMS.Models.Result>? Result { get; set; }
    }
}
