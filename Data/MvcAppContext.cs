using Microsoft.EntityFrameworkCore;
using MVCApp.Models;
using Microsoft.EntityFrameworkCore.Migrations;


namespace MVCApp.Data;

public class MvcAppContext : DbContext
{
    public MvcAppContext(DbContextOptions<MvcAppContext> options) : base(options)
    {

    }


  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shop>(entity =>
        {
            entity.Property<int>(e => e.ShopId);

            entity.Property(e => e.ShopAddress).HasDefaultValue("Prafull");

            entity.Property(e => e.price3).HasDefaultValue(100);
        });

        //modelBuilder.Entity<Shop>(entity =>
        //{
        //    //entity.Property(e => e.ShopAddress).HasDefaultValue("xyz");

        //    entity.Property(e => e.price3).HasDefaultValue("100");



        //});




    }
    public DbSet<Items> Items { get; set; }
    public DbSet<Shop> shops { get; set; }
    public DbSet<Blog> blogs { get; set; }
    public DbSet<Post> posts { get; set; }
    public DbSet<PostPrice> PostPrice { get; set; }
    public DbSet<CompositePrimaryKey> compositePrimaryKey { get; set; }
    public DbSet<CompositePrimaryKey2> compositePrimaryKey2 { get; set; }

    //DbSet<ManyToMany1> manyToMany1 { get; set; }
    //DbSet<ManyToMany2> manyToMany2 { get; set; }
}
