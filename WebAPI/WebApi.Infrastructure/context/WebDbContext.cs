using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.VModels;

namespace WebAPI.Infrastructure.context
{
    public class WebDbContext : DbContext
    {
        public WebDbContext() { }
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options) { }

        public virtual DbSet<UserMaster> userMasters { get; set; }



         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             if (!optionsBuilder.IsConfigured)
             {
                optionsBuilder.UseSqlServer(" "); // enter your connection string
             }
         }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             
         }

    }
}
