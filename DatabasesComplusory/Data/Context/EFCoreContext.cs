using System.Runtime.InteropServices.Marshalling;
using Microsoft.EntityFrameworkCore;
using DatabasesComplusory.Models.Write;

namespace DatabasesComplusory.Data.Context;

public class EFCoreContext :DbContext
{
    public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
    {
        
    }
    
    public DbSet<Listing> Listings { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Listing>()
            .HasKey(l => l.ListingId);

        modelBuilder.Entity<Order>()
            .HasKey(o => o.OrderId);

        modelBuilder.Entity<Review>()
            .HasKey(r => r.ReviewId);

        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);

        // Links Review to Seller
        modelBuilder.Entity<Review>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(r => r.SellerId);

        // Links Review to User who made Review
        modelBuilder.Entity<Review>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(r => r.UserId);
        
        // Links Order to Listing
        modelBuilder.Entity<Order>()
            .HasOne<Listing>()
            .WithMany()
            .HasForeignKey(o => o.ListingId);

        // Links Order to User placing Order
        modelBuilder.Entity<Order>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.UserId);
        
        // Links Listing to Seller
        modelBuilder.Entity<Listing>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.SellerId);
        
        // Links Listing to Media
        modelBuilder.Entity<Media>()
            .HasOne<Listing>()
            .WithMany()
            .HasForeignKey(e => e.ListingId);
            
    }
    
}
