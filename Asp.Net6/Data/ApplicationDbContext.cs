using Asp.Net6.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net6.Data
{
    public class ApplicationDbContext:DbContext
    {
        //Constructor 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Alumno> Alumno { get; set; }

        public DbSet<Curso> Curso { get; set; }

        public DbSet<Nota> Nota { get; set; }


    }
}
