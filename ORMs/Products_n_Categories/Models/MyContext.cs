using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Products_n_Categories.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Association> Associations {get; set;}
    }
}