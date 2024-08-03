using Microsoft.EntityFrameworkCore;
using SudentPortalWeb.Models.Entities;

namespace SudentPortalWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
