using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure.Models;

namespace WebAPI.context
{
    public class WebDbContext : DbContext
    {
        public WebDbContext() { }
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options) { }

        public virtual DbSet<UserMaster> userMasters { get; set; }
    }
}
