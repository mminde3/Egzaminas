using Microsoft.EntityFrameworkCore;
using Pastomatas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pastomatas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PostPackageModel> PostPackages { get; set; }
        public DbSet<PostTerminalModel> PostTerminals { get; set; }

    }
}
