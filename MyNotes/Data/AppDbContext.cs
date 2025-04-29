using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyNotes.Models;

namespace MyNotes.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }

    }
}





//using Microsoft.EntityFrameworkCore;
//using MyNotes.Models;

//namespace MyNotes.Data
//{
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext()
//        {

//        }

//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//        public DbSet<Note> Notes { get; set; }

//    }
//}
