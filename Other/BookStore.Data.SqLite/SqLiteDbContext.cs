namespace BookStore.Data.SqLite
{
    using System.Data.Entity;

    using BookStore.Data.SqLite.Models;

    public class SqLiteDbContext : DbContext
    {
        public SqLiteDbContext() : base("CityStores")
        {
        }

        public IDbSet<Library> Libraries { get; set; }

        public IDbSet<City> Cities { get; set; }
    }
}
