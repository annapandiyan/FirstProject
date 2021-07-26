using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class NameContext : DbContext
    {
        public NameContext(DbContextOptions<NameContext> options)
            : base(options)
        {
        }
        public DbSet<NameItem> Plans { get; set; }
    }
}
