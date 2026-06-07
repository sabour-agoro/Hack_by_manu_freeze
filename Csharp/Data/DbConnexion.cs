using Microsoft.EntityFrameworkCore;
using Csharp.Models;


namespace Csharp.Data
{
    public class dbConnexion : DbContext
    {
        public dbConnexion(DbContextOptions<dbConnexion> options) : base(options)
        {
           
        }
        public DbSet<AcademicYear> academicYears {get; set;}
        public DbSet<Students> students {get; set;}
        public DbSet <Classe> classes {get; set;}
        
    }
}