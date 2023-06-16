using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EBookStoreDbContext : DbContext
    {


        public EBookStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public EBookStoreDbContext()
        {
        }

        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<BookAuthor> BookAuthors{ get; set; } = null!;
        public DbSet<Book> Books  { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;
        public DbSet<User> Users{ get; set; } = null!;
        public DbSet<Role> Roles{ get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //var builder = new ConfigurationBuilder()
            //               .SetBasePath(Directory.GetCurrentDirectory())
            //               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer("server =(local); database = EBookStore;uid=sa;pwd=123;trusted_connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.PubId);

            modelBuilder.Entity<User>()
                .HasOne(b => b.Publisher)
                .WithMany(a => a.Users)
                .HasForeignKey(b => b.PubId);
        }

       
    }
}
