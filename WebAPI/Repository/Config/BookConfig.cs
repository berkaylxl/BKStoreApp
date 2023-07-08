using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using WebAPI.Models;

namespace WebAPI.Repository.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Denemeler", Price =80},
                new Book { Id = 2, Title = "Devlet", Price = 180 },
                new Book { Id = 3, Title = "Nutuk", Price = 280 }
                );
                
        }
    }
}
