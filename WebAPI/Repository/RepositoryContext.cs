using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Repository.Config;

namespace WebAPI.Repository
{
    public class RepositoryContext:DbContext
    {

        public RepositoryContext(DbContextOptions options) : base(options)
        {
           
        }
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }   
}
