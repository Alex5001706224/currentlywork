using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace OnlineShoppingWeb.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacture>? Manufactures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacture>().HasData(
                new Manufacture {MakeId = 1, MakeName = "LG"},
                new Manufacture { MakeId = 2, MakeName = "SamSung" },
                new Manufacture { MakeId = 3, MakeName = "GE" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product 
                {
                    Id= 1, 
                    MakeId = 2, 
                    Item = Category.Dishwasher, 
                    Name = "SamSung Front Control Dishwasher",
                    Description = "Height : 32 1/6 inches\r\n Width : 23 5/8 inches\r\n Depth: 22 7/8 inches" +
                "\r\n Color : Stainless steel", 
                    Model = "52dBA", 
                    Price = 719.99, 
                    ImageName = "52dBA.webp", 
                    Manufacture = Make.SamSung
                },
                new Product
                {
                    Id = 2,
                    MakeId = 1,
                    Item = Category.Washer,
                    Name = "LG Smart Front Load Washer",
                    Description = "Height : 39 inches\r\n Width : 27 inches\r\n Depth: 30.25 inches\r\n Capacity : 4.5 cu. ft\r\n Color : Stainless steel",
                    Model = "DLE3600V",
                    Price = 1048,
                    ImageName = "DLE3600V.webp",
                    Manufacture = Make.LG
                },
                new Product
                {
                    Id = 3,
                    MakeId=2,
                    Item = Category.Stove,
                    Name = "Samsung - 5.8 Cu. Ft. Self-Cleaning Freestanding Gas Range ",
                    Description = "Height : 46 7/10 inches\r\n Width : 29 9/10 inches\r\n Depth: 28 3/10 inches\r\n  Color : Stainless steel",
                    Model = "NX58R4311SS-AA",
                    Price = 1078,
                    ImageName = "NX58R4311SS-AA.webp",
                    Manufacture = Make.SamSung
                },
                new Product
                {
                    Id = 4,
                    MakeId = 1,
                    Item = Category.Refrigerator,
                    Name = "LG Energy Star Rated French Door Refrigerator",
                    Description = "Height : 39 inches\r\n Width : 27 inches\r\n Depth: 30.25 inches\r\n Capacity : 4.5 cu. ft\r\n Color : Stainless steel",
                    Model = "LFDS22520",
                    Price = 1999,
                    ImageName = "LFDS22520.webp",
                    Manufacture = Make.LG
                }
                );
        }
    }
}
