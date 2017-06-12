namespace BookStore.Data
{
    using BookStore.Models;
    using System.Data.Entity;

    public class BookStoreContext : DbContext
    {
        public BookStoreContext()
            : base("Store")
        {
    }


        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}