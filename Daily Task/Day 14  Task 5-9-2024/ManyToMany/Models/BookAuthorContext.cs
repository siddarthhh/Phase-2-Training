using Microsoft.EntityFrameworkCore;

namespace API_Many_to_Many__C_.Models
{
    public class BookAuthorContext :DbContext
    {
       

        public DbSet<Book> books { get; set; }  

        public DbSet<Author> author { get; set; }

        public DbSet<BookAuthor> BookAuthor { get; set; }

        public BookAuthorContext(DbContextOptions<BookAuthorContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                 .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(a => a.BookList)
                .HasForeignKey(a => a.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(ba => ba.BookAuthorList)
                .HasForeignKey(a => a.AuthorId);

        }
    }
}
