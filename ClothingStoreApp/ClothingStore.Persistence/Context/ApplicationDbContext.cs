using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ClothingStore.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Variant> Variants { get; set; }
        public virtual DbSet<AvailableLocationBySize> AvailableLocations { get; set; }
        public virtual DbSet<StockByLocation> StocksByLocations { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            //base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new InvalidOperationException("DbContext was not configured. Use AddDbContext in DI or pass options to the ctor.");
            }
        }

    }
}
