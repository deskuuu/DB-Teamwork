namespace BookStore.Data.SqlServer
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.Data.SqlServer.BookStoreContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Data.SqlServer.BookStoreContext context)
        {
            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data. E.g.
            ////
            ////    context.People.AddOrUpdate(
            ////      p => p.FullName,
            ////      new Person { FullName = "Andrew Peters" },
            ////      new Person { FullName = "Brice Lambson" },
            ////      new Person { FullName = "Rowan Miller" }
            ////    );
        }
    }
}
