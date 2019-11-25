using CW2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW2.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Book_Category> Book_Cat { get; set; }
        public DbSet<Result> Resl { get; set; }
        public DbSet<Rootobject> RootOb { get; set; }
        public DbSet<Results> Resul { get; set; }
        public DbSet<Book> B { get; set; }
        public DbSet<Isbn> Isb { get; set; }
        public DbSet<Buy_Links> b_link { get; set; }
        public DbSet<DataPoint> dP { get; set; }
    }
}

