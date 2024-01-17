using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestMcfMVC.Models;

namespace TestMcfMVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<LocationModel> ms_storage_location { get; set; }
    }
}
