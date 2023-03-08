using Crud.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.DataAccess
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
