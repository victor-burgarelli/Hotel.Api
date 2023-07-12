using Hotel.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<HotelsModel> Hotels { get; set; }
        public DbSet<AddressesModel> Addresses { get; set; }
        public DbSet<CategoriesModel> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Categories = Set<CategoriesModel>();
            Hotels = Set<HotelsModel>();
            Addresses = Set<AddressesModel>();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HotelsModel>()
                .HasKey(h => h.Id);

            builder.Entity<AddressesModel>()
                .HasKey(a => a.Id);

            builder.Entity<CategoriesModel>()
                .HasKey(c => c.Id);

            builder.Entity<HotelsModel>()
                .HasOne(h => h.Category)
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<HotelsModel>()
            .Property(h => h.PricePerNight)
            .HasPrecision(18, 2);

            builder.Entity<HotelsModel>()
                .HasOne(h => h.Address)
                .WithOne(a => a.Hotel)
                .HasForeignKey<AddressesModel>(a => a.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
