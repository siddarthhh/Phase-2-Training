using Microsoft.EntityFrameworkCore;

namespace ManyToManyApi.Models
{
    public class BookAuthorDbContext : DbContext
    {
        public DbSet<BookAuthor>? bookAuthorSet { get; set; }
        public DbSet<Book>? books { get; set; }
        public DbSet<Author>? author { get; set; }

        public BookAuthorDbContext (DbContextOptions<BookAuthorDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                 .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.book)
                .WithMany(a => a.bookList)
                .HasForeignKey(a => a.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.author)
                .WithMany(ba => ba.bookAuthorsList)
                .HasForeignKey(a => a.AuthorId);

        }

    }
}
