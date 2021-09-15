using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miniShop.Business;
using miniShop.Extensions;
using miniShop.Infrastructure;
using miniShop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    public class CartController : Controller
    {
        private IProductService productService;

        public CartController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index([ModelBinder(BinderType = typeof(SessionModelBinder))]ShoppingCard productCard)
        {
            //var productCard = HttpContext.Session.GetJson<ShoppingCard>("card") ?? new ShoppingCard();
            return View(productCard);
        }

        
        public IActionResult AddToCart(int id)
        {
            var selectedProduct = productService.GetProduct(id);
            if (selectedProduct != null)
            {
                ShoppingCard shoppingCard = getShoppingCardFromSession();
                shoppingCard.AddProductToCard(selectedProduct, 1);
                saveSession(shoppingCard);
            }
            return Json(selectedProduct.Name);
        }

        private void saveSession(ShoppingCard shoppingCard)
        {
            HttpContext.Session.SetJson("card", shoppingCard);
        }

        ShoppingCard getShoppingCardFromSession()
        {
            //ShoppingCard shoppingCard = null;

            //if (HttpContext.Session.GetString("card")==null)
            //{
            //    //eğer card isminde bir session yoksa, demek ki ilk kez bu metod çağrılıyor.
            //    shoppingCard = new ShoppingCard();
            //    HttpContext.Session.SetJson("card", shoppingCard);
            //}

            //var data = HttpContext.Session.GetString("card");
            //return JsonConvert.DeserializeObject<ShoppingCard>(data);

            ShoppingCard shoppingCard = HttpContext.Session.GetJson<ShoppingCard>("card") ?? new ShoppingCard();
            return shoppingCard;
            
        }
    }
}
