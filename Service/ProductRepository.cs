using OnlineShoppingWeb.Models;

namespace OnlineShoppingWeb.Service
{
    public class ProductRepository : IproductRepository
    {
        private List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>();
            products.Add(new Product() 
            { Id= 1, 
              Item = Category.Dishwasher, 
              Name = "SamSung Front Control Dishwasher", 
              Description = "Height : 32 1/6 inches\n Width : 23 5/8 inches\n Depth: 22 7/8 inches\n Color : Stainless steel", 
              Model = "52dBA", 
              Price = 719.99, 
              ImageName = "52dBA.webp", 
              Manufacture = Make.SamSung
            });
            products.Add(new Product()
            {
                Id = 2,
                Item = Category.Washer,
                Name = "LG Smart Front Load Washer",
                Description = "Height : 39 inches\r\n Width : 27 inches\r\n Depth: 30.25 inches\r\n Capacity : 4.5 cu. ft\r\n Color : Stainless steel",
                Model = "DLE3600V",
                Price = 1048,
                ImageName = "DLE3600V.webp",
                Manufacture = Make.LG
            });
            products.Add(new Product()
            {
                Id = 3,
                Item = Category.Stove,
                Name = "Samsung - 5.8 Cu. Ft. Self-Cleaning Freestanding Gas Range ",
                Description = "Height : 46 7/10 inches\r\n Width : 29 9/10 inches\r\n Depth: 28 3/10 inches\r\n  Color : Stainless steel",
                Model = "NX58R4311SS-AA",
                Price = 1048,
                ImageName = "NX58R4311SS-AA.webp",
                Manufacture = Make.SamSung
            });
            products.Add(new Product()
            {
                Id = 4,
                Item = Category.Refrigerator,
                Name = "LG Energy Star Rated French Door Refrigerator",
                Description = "Height : 39 inches\r\n Width : 27 inches\r\n Depth: 30.25 inches\r\n Capacity : 4.5 cu. ft\r\n Color : Stainless steel",
                Model = "LFDS22520",
                Price = 1999,
                ImageName = "LFDS22520.webp",
                Manufacture = Make.LG
            });

        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var product = products.Find(x => x.Id == id);
            if(product != null)
            {
                products.Remove(product);
            }
        }

        public int GetMaxId()
        {
            int id = products.Max(x => x.Id);
            return id;
        }

        public Product GetProduct(int id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return products.Find(x => x.Id == id);
            }
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {
            var prod = products.Find(x => x.Id == product.Id);
            if (prod != null)
            {
                prod.Id = product.Id;
                prod.Item = product.Item;
                prod.Name = product.Name;
                prod.Price = product.Price;
                prod.Model = product.Model;
                prod.Description = product.Description;
                prod.ImageName = product.ImageName;
                prod.Manufacture = product.Manufacture;
            }
        }
    }
}
