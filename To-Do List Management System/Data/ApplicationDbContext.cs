// while making this file:
// 1. Make a new class of dbcontext
// 2. Install entityframeworkcore package
// 3. Use DbContext class inside our class

using Microsoft.EntityFrameworkCore;
using To_Do_List_Management_System_.Models;

namespace To_Do_List_Management_System_.Data
{
    public class ApplicationDbContext : DbContext
    {

        //For the DbContext class to be able to do any useful work, it needs an
        //instance of the DbContextOptions class.
        //The DbContextOptions instance carries configuration information
        //such as the connection string, database provider to use etc.

        //This constructor is like a general sytax needed to establish connection with entityframework
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        public DbSet<todo> TODOs { get; set; }
    }
}
