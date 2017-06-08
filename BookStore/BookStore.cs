namespace BookStore
{
    using global::BookStore.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookStoreContext : DbContext
    {
        // Your context has been configured to use a 'BookStore' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookStore.BookStore' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookStore' 
        // connection string in the application configuration file.
        public BookStoreContext()
            : base("Store")
        {
    }


        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}