using OnlineShoppingWeb.Models;

namespace OnlineShoppingWeb.Service
{
    public class DBCRUDRRepository : IproductRepository
    {
        private ProductContext _productContext;
        public DBCRUDRRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public void AddProduct(Product product)
        {
            if(product.Manufacture.ToString() == "LG")
            {
                product.MakeId = 1;
            }
            if (product.Manufacture.ToString() == "SamSung")
            {
                product.MakeId = 2;
            }
            if (product.Manufacture.ToString() == "GE")
            {
                product.MakeId = 3;
            }
            _productContext.Products.Add(product);
            _productContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var prod = _productContext.Products.Find(id);
            if(prod != null)
            {
                _productContext.Products.Remove(prod);
                _productContext.SaveChanges();
            }
        }

        public int GetMaxId()
        {
            return _productContext.Products.Max(x => x.Id) + 1;
        }
        //public List<Product> findAll()
        //{
        //    return _productContext.Products.ToList();
        //    //var list = new List<Product>();
        //    //return list;
        //}

        public Product GetProduct(int id)
        {
            return _productContext.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return _productContext.Products.ToList<Product>();
        }

        public void UpdateProduct(Product product)
        {
            var prod = _productContext.Products.Find(product.Id);
            if(product != null)
            {
                prod.Id = product.Id;
                prod.Name = product.Name;
                prod.Description = product.Description;
                prod.Model = product.Model;
                prod.Price = product.Price;
                prod.Item = product.Item;
                prod.ImageName = product.ImageName;
                prod.Manufacture = product.Manufacture;
                if(product.Manufacture.ToString() == "LG")
                {
                    product.MakeId = 1;
                }
                if (product.Manufacture.ToString() == "SamSung")
                {
                    product.MakeId = 2;
                }
                if (product.Manufacture.ToString() == "GE")
                {
                    product.MakeId = 3;
                }
                _productContext.SaveChanges();
            }
        }
    }
}
