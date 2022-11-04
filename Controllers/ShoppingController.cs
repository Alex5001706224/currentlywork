using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Models;
using OnlineShoppingWeb.Service;
using OnlineShoppingWeb.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using OnlineShoppingWeb.Helpers;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Web;


namespace OnlineShoppingWeb.Controllers
{
    [Route("cart")]
    public class ShoppingController : Controller
    //{
    //    private IproductRepository productR;

    //    //private List<ShoppingCartModel> listOfShoppingCartModels;
    //    public ShoppingController(IproductRepository productR)
    //    {
    //        this.productR = productR;
    //    }
    //    public IActionResult Add(int id)
    //    {
    //        var po = productR.GetProduct(id);
    //        if (po == null)
    //        {
    //            List<Product> li = new List<Product>();

    //            ViewBag.carts = li.Count();
    //            HttpContext.Session.SetInt32("id", id);
    //        }
    //        else
    //        {

    //        }
    //        return RedirectToAction("Index", "Home");
    //    }
    //}

    {
        private IproductRepository productR;

        //private List<ShoppingCartModel> listOfShoppingCartModels;
        public ShoppingController(IproductRepository productR)
        {
            this.productR = productR;
        }
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelpers.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            //ProductModel productModel = new ProductModel();
            if (SessionHelpers.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productR.GetProduct(id), Quantity = 1 });
                SessionHelpers.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelpers.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productR.GetProduct(id), Quantity = 1 });
                }
                SessionHelpers.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelpers.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelpers.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Item> cart = SessionHelpers.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

    } 

}

