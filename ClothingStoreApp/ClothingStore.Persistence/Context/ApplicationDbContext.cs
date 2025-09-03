using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ClothingStore.Domain.Enumerators;
namespace ClothingStore.Persistence.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<AvailableLocationBySize> AvailableLocations { get; set; }
        public DbSet<StockByLocation> StocksByLocations { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }


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
