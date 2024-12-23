using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.DataAccess.Context
{
    public class TeacherManagementContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6J2APNJ;Database=TeacherManagement;Integrated Security=True;");
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
