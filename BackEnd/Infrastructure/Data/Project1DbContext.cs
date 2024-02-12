using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data
{
    public class Project1DbContext : DbContext
    {
        public Project1DbContext(DbContextOptions<Project1DbContext> options) : base(options)
        {
        }

        //protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        //{
        //    builder.Properties<DateOnly>()
        //        .HaveConversion<DateOnlyConverter>()
        //        .HaveColumnType("date");
        //}

        //public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        //{
        //    public DateOnlyConverter() : base(
        //            d => d.ToDateTime(TimeOnly.MinValue),
        //            d => DateOnly.FromDateTime(d))
        //    { }
        //}
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Publisher> Publishers { get; set; }
    }
}