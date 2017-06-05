namespace BookReservationSystem.Migrations
{
    using BookReservationSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookReservationSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BookReservationSystem.Models.ApplicationDbContext";
        }

        protected override void Seed(BookReservationSystem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.BookCategories.AddOrUpdate(new BookCategory()
            {
                Id = (int)BookCategoryEnum.Comedy,
                Name = BookCategoryEnum.Comedy.ToString()
            });

            context.BookCategories.AddOrUpdate(new BookCategory()
            {
                Id = (int)BookCategoryEnum.Criminal,
                Name = BookCategoryEnum.Criminal.ToString()
            });

            context.BookCategories.AddOrUpdate(new BookCategory()
            {
                Id = (int)BookCategoryEnum.Fantasy,
                Name = BookCategoryEnum.Fantasy.ToString()
            });

            context.BookCategories.AddOrUpdate(new BookCategory()
            {
                Id = (int)BookCategoryEnum.Romanse,
                Name = BookCategoryEnum.Romanse.ToString()
            });

            context.BookCategories.AddOrUpdate(new BookCategory()
            {
                Id = (int)BookCategoryEnum.SciFi,
                Name = BookCategoryEnum.SciFi.ToString()
            });

            context.SaveChanges();
        }
    }
}
