using Microsoft.EntityFrameworkCore;

namespace TestMcfAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<BPKB> tr_Bpkb { get; set; }
        public DbSet<Users> ms_user { get; set; }

        public DbSet<Location> ms_storage_location { get; set; }
    }
}
