using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEfCode.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {     
        }
        //this constructor is basically used to pass the options setting to the base DbContext Class.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyType>().HasData(
                new CurrencyType() { Id = 1, Currency = "INR" },
                new CurrencyType() { Id = 2, Currency = "Dollar"},
                new CurrencyType() { Id = 3, Currency = "Euro"},
                new CurrencyType() { Id = 4, Currency = "Dinar"});

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Title = "Hindi", Description = "Indian mothertounge" },
                new Language() { Id = 2, Title = "English", Description = "American mothertounge" },
                new Language() { Id = 3, Title = "Malyalam", Description = "Kerala mothertounge" },
                new Language() { Id = 4, Title = "Telugu", Description = "Tamil Nadu's mothertounge" });

            modelBuilder.Entity<BookPrice>().HasData(
                new BookPrice() { Id = 1, Amount = 854, CurrencyTypeId = 3, BookId = 3 },
                new BookPrice() { Id = 2, Amount = 265, CurrencyTypeId = 2, BookId = 2 },
                new BookPrice() { Id = 3, Amount = 658, CurrencyTypeId = 4, BookId = 4 },
                new BookPrice() { Id = 4, Amount = 458, CurrencyTypeId = 1, BookId = 1 });

            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Title = "It Ends With Us", Description = "Rom", IsActive=true, LanguageId=3, country="India" },
                new Book() { Id = 2, Title = "Rememberence of him", Description = "Relationships", IsActive = false, LanguageId = 2, country = "Spain" },
                new Book() { Id = 3, Title = "Malala", Description = "The Pakistani gurl", IsActive = true, LanguageId = 4, country = "Paris" },
                new Book() { Id = 4, Title = "The Alchemist", Description = "about a group of shephered", IsActive = true, LanguageId = 1, country = "HongKong" });
        }
        //we want to make changes in the existing classes
        public DbSet<Book> Books { get; set; }
        //here Books is teh name of the table  in the DB and Book is teh name of teh class corrosponding to Books

        public DbSet<Language> Languages { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }

        public DbSet<Author> AuthorS { get; set; }
     
    }
}
