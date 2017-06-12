namespace BookStore.Data.SqlServer
{
    using System.Data.Entity;

    using BookStore.Data.SqlServer.Models;

    public class BookStoreContext : DbContext
    {
        public BookStoreContext()
            : base("Store")
        {
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<Series> Series { get; set; }

        public IDbSet<Category> Categories { get; set; }

        ////protected override void OnModelCreating(DbModelBuilder modelBuilder)
        ////{
        ////    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        ////    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
     
        ////    base.OnModelCreating(modelBuilder);
        ////}
    }
}