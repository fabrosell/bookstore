using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Domain.Models;

namespace Bookstore.Infra.Data.Context
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }        
    }
}
