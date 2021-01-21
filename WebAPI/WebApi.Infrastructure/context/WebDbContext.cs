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



        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             if (!optionsBuilder.IsConfigured)
             {
                 Console.WriteLine("not configured");
             }
         }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<UserMaster>(b =>
             {
                 b.Property<int>("UserId")
                     .ValueGeneratedOnAdd()
                     .HasColumnType("int")
                     .UseIdentityColumn();

                 b.Property<int?>("CreatedBy")
                     .HasColumnType("int");

                 b.Property<DateTime?>("CreatedTime")
                     .HasColumnType("datetime2");

                 b.Property<DateTime>("DateOfBirth")
                     .HasColumnType("datetime2");

                 b.Property<string>("FirstName")
                     .HasColumnType("nvarchar(max)");

                 b.Property<string>("Gender")
                     .HasColumnType("nvarchar(max)");

                 b.Property<string>("LastName")
                     .HasColumnType("nvarchar(max)");

                 b.Property<string>("MailId")
                     .HasColumnType("nvarchar(max)");

                 b.Property<int?>("UpdatedBy")
                     .HasColumnType("int");

                 b.Property<DateTime?>("UpdatedTime")
                     .HasColumnType("datetime2");

                 b.Property<string>("UserName")
                     .HasColumnType("nvarchar(max)");

                 b.HasKey("UserId");

                 b.ToTable("userMasters");
             });
         }*/

    }
}
