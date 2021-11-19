using Microsoft.EntityFrameworkCore;

namespace BT_BuildingsDAL
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingImage> BuildingImages { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
